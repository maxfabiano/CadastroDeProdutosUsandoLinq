using Data;
using Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using CadastroProdutos.Request;
using CadastroProdutos.Response;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
List<Categoria> categorias = new List<Categoria>();



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});


MySqlConnection conexao = new MySqlConnection(builder.Configuration.GetConnectionString("WebApiDatabase"));
conexao.Open();

//builder.Services.AddEntityFrameworkMySQL().AddDbContext<DbContext>(options => {
//  options.UseMySQL(builder.Configuration.GetConnectionString("WebApiDatabase"));
//});
var app = builder.Build();
app.UseHttpsRedirection();
var con = new Context();

app.MapPost("/api/security/createToken",
    [EnableCors("AllowOrigin")]
[AllowAnonymous] async (CadastroProdutos.Request.LoginRequest request) =>
    {
        try
        {
            var usuarios = await con.Usuarios.ToListAsync();

            List<Usuario> result = usuarios.Where(x => x.LoginUsuario.Equals(request.Username) && x.SenhaPass.Equals(request.Password)).ToList();
            Console.WriteLine(result);
            if (result.Count() > 0)
            {
                var issuer = builder.Configuration["Jwt:Issuer"];
                var audience = builder.Configuration["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes
                (builder.Configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, "1"),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                Console.WriteLine(JsonConvert.SerializeObject(new MessageResponse("Sucesso ao efetuar login", stringToken, true, result[0])));
                return JsonConvert.SerializeObject(new MessageResponse("Sucesso ao efetuar login", stringToken, true, result[0]));
            }
            else
            {
                return JsonConvert.SerializeObject(new MessageResponse("Erro ao efetuar login", "", false, ""));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return JsonConvert.SerializeObject(new MessageResponse("Erro ao efetuar login", "", false, ""));

        }
    });
app.MapGet("/api/getProduto/{filial}",
 [EnableCors("AllowOrigin")]
[AllowAnonymous] async (string filial) =>
 {
     try
     {

         //var ProdutosResponse = await con.Produtos.Where(x=> x.Filial.Equals(filial)).ToListAsync();
         var ProdutosResponse = await con.Produtos.ToListAsync();

         return JsonConvert.SerializeObject(ProdutosResponse);
     }
     catch (Exception ex)
     {
         return JsonConvert.SerializeObject(new MessageResponse(ex.Message, "", false, ""));
     }
 });
app.MapGet("/api/getCliente/{CODFIL}",
 [EnableCors("AllowOrigin")]
[AllowAnonymous] async (string CODFIL) =>
 {
     try
     {

         var ClientesResponse = await con.Clientes.ToListAsync();
         return JsonConvert.SerializeObject(ClientesResponse.Take(10));
     }
     catch (Exception ex)
     {
         return JsonConvert.SerializeObject(new MessageResponse(ex.Message, "", false, ""));
     }
 });
app.MapGet("/api/getEndereco",
 [EnableCors("AllowOrigin")]
[AllowAnonymous] async () =>
 {
     try
     {
         var EnderecosResponse = await con.Enderecos.ToListAsync();
         return JsonConvert.SerializeObject(EnderecosResponse.Take(10));
     }
     catch (Exception ex)
     {
         return JsonConvert.SerializeObject(new MessageResponse(ex.Message, "", false, ""));
     }
 });

app.MapGet("/api/getCategoria",
[EnableCors("AllowOrigin")]
[AllowAnonymous] async () =>
{
    using (var context = new Context())
    {
        try
        {

            categorias = await Task.Run(() => context.Categoria.ToListAsync());

        }
        catch (Exception ex)
        {
            return JsonConvert.SerializeObject(new MessageResponse(ex.Message, "", false, ""));
        }
        return JsonConvert.SerializeObject(categorias);
    }
});

//http pos addProduto header fwt token
app.MapPost("/api/addProduto",
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("AllowOrigin")]
async (Produto produto) =>
    {
        try
        {
            produto.fotoConvert();
            con.Produtos.Add(produto);
            await con.SaveChangesAsync();
            // Mantenha a string do token e atualize o tempo de expiração do token

            return JsonConvert.SerializeObject(new MessageResponse("Sucesso ao adicionar produto", "", true, ""));
        }
        catch (Exception ex)
        {
            con.Produtos.Remove(produto);
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string strJson = System.Text.Json.JsonSerializer.Serialize<Produto>(produto, opt);
            Console.WriteLine(strJson);
            return JsonConvert.SerializeObject(new MessageResponse(ex.Message, "", false, ""));
        }
    });


app.MapPost("/api/addPedido",
[EnableCors("AllowOrigin")]
async (Pedido pedido) =>
{
    try
    {
        con.Pedidos.Add(pedido);
        await con.SaveChangesAsync();
        return JsonConvert.SerializeObject(new MessageResponse("Sucesso ao adicionar pedido", "", true, ""));

    }
    catch (Exception ex)
    {
        con.Pedidos.Remove(pedido);
        var opt = new JsonSerializerOptions() { WriteIndented = true };
        string strJson = System.Text.Json.JsonSerializer.Serialize<Pedido>(pedido, opt);
        return JsonConvert.SerializeObject(new MessageResponse(ex.Message, "", false, ""));
    }
});



//http put editarproduto id header fwt token
app.MapPut("/api/produtos/produto/{id}",
[EnableCors("AllowOrigin")]
async (int id, Produto produto) =>
{
    try
    {
        var produtoAntigo = await con.Produtos.Where(x => x.IdProd == id).FirstOrDefaultAsync();
        produtoAntigo = produto;
        await con.SaveChangesAsync();
        return JsonConvert.SerializeObject(new MessageResponse("Sucesso ao editar produto", "", true, ""));
    }
    catch (Exception erro)
    {
        return JsonConvert.SerializeObject(new MessageResponse("Erro ao editar produto", "", false, erro.Message));
    }
});

//http delete deletarproduto id header fwt token
app.MapDelete("/api/produtos/produto/{id}",
[EnableCors("AllowOrigin")]
async (int id) =>
{
    try
    {
        var produto = con.Produtos.Where(x => x.IdProd == id).FirstOrDefault();
        con.Produtos.Remove(produto);
        await con.SaveChangesAsync();
        return JsonConvert.SerializeObject(new MessageResponse("Sucesso ao deletar produto", "", true, ""));
    }
    catch (Exception erro)
    {
        return JsonConvert.SerializeObject(new MessageResponse("Erro ao deletar produto", "", false, erro.Message));
    }
});
// Add services to the container.
builder.Services.AddControllersWithViews();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
