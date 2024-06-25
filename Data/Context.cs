using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySql.EntityFrameworkCore.Extensions;
namespace Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }
        protected readonly IConfiguration Configuration;

        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public Context(DbContextOptions<Context> options)
          //  : base(options)
        //{
        //

        public virtual DbSet<Caixa> Caixas { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Complemento> Complementos { get; set; } = null!;
        public virtual DbSet<Cupon> Cupons { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<FormaPagamento> FormaPagamentos { get; set; } = null!;
        public virtual DbSet<Motoboy> Motoboys { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Receitum> Receita { get; set; } = null!;
        public virtual DbSet<RegistroOcorrencium> RegistroOcorrencia { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {

                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySQL("Server=127.0.0.1; Port=3310; Database=coinfood; Uid=root; Pwd=Max@6511");

                }
                optionsBuilder.EnableSensitiveDataLogging();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CODCAT)
                    .HasName("PK__CLIENTE__23A34130F4808431");

                entity.ToTable("M004CATEG");
                entity.Property(e => e.DATACAD).HasColumnName("DATACAD");
                entity.Property(e => e.NOME).HasColumnName("NOME");
                entity.Property(e => e.FOTO).HasColumnName("FOTO");
                entity.Property(e => e.DATACAD).HasColumnName("DATACAD");
                entity.Property(e => e.CODEMP).HasColumnName("CODEMP");
                entity.Property(e => e.D_E_L_E_T_E).HasColumnName("D_E_L_E_T");

            });

                modelBuilder.Entity<Caixa>(entity =>
            {
                entity.HasKey(e => e.IdCaixa)
                    .HasName("PK__CAIXA__774938AE8B52FE6B");

                entity.ToTable("CAIXA");

                entity.Property(e => e.IdCaixa)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CAIXA");

                entity.Property(e => e.AddCaixa)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("ADD_CAIXA");

                entity.Property(e => e.DataAbertura)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_ABERTURA");

                entity.Property(e => e.DataFechamento)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_FECHAMENTO");

                entity.Property(e => e.DataRetirada)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_RETIRADA");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO");

                entity.Property(e => e.Filial).HasColumnName("FILIAL");

                entity.Property(e => e.IdPagamentoCaix).HasColumnName("ID_PAGAMENTO_CAIX");

                entity.Property(e => e.IdPedCaix).HasColumnName("ID_PED_CAIX");

                entity.Property(e => e.IdUsuarioCaixa).HasColumnName("ID_USUARIO_CAIXA");

                entity.Property(e => e.RetirarCaixar)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("RETIRAR_CAIXAR");

                entity.Property(e => e.ValorAbertura)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("VALOR_ABERTURA");

                entity.Property(e => e.ValorFechamento)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("VALOR_FECHAMENTO");

                

              

                /*entity.HasOne(d => d.IdUsuarioCaixaNavigation)
                    .WithMany(p => p.Caixas)
                    .HasForeignKey(d => d.IdUsuarioCaixa)
                    .HasConstraintName("FK_USUARIO_CAIXA");*/
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CODCLI)
                    .HasName("PK__CLIENTE__23A34130F4808431");

                entity.ToTable("M001CLI");

                entity.Property(e => e.CODCLI)
                    .ValueGeneratedNever()
                    .HasColumnName("CODCLI");

                entity.Property(e => e.DOCCLI)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("DOCCLI");

                entity.Property(e => e.D_E_L_E_T_)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("D_E_L_E_T_");

                entity.Property(e => e.DATCAD)
                    .HasColumnType("datetime")
                    .HasColumnName("DATCAD");

                entity.Property(e => e.DATNAS)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DATNAS");

                entity.Property(e => e.EMAIL)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.CODFIL)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CODFIL");

                entity.Property(e => e.ENDPAD).HasColumnName("ENDPAD");

                entity.Property(e => e.NOMCLI)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOMCLI");

                entity.Property(e => e.NOTCLI).HasColumnName("NOTCLI");

                entity.Property(e => e.OBSCLI)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OBSCLI");

               

                entity.Property(e => e.CODPWS)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CODPWS");

                entity.Property(e => e.TELCLI)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELCLI");

                
            });

            modelBuilder.Entity<Complemento>(entity =>
            {
                entity.HasKey(e => e.IdCompl)
                    .HasName("PK__COMPLEME__488767075BDF01A7");

                entity.ToTable("COMPLEMENTO");

                entity.Property(e => e.IdCompl)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_COMPL");

                entity.Property(e => e.CategCompl)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CATEG_COMPL");

                entity.Property(e => e.CodIntegrador)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COD_INTEGRADOR");

                entity.Property(e => e.DELETE)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("D_E_L_E_T_E_");

                entity.Property(e => e.DatCad)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CAD");

                entity.Property(e => e.DataCusto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DATA_CUSTO");

                entity.Property(e => e.Filial)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FILIAL");

                entity.Property(e => e.Foto).HasColumnName("foto");

                entity.Property(e => e.IdReceitCompl).HasColumnName("ID_RECEIT_COMPL");

                entity.Property(e => e.NomeCompl)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME_COMPL");

                entity.Property(e => e.QntdCompl)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("QNTD_COMPL");

                entity.Property(e => e.ValorCusto)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("VALOR_CUSTO");

                entity.Property(e => e.ValorVenda)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("VALOR_VENDA");

                entity.HasOne(d => d.IdReceitComplNavigation)
                    .WithMany(p => p.Complementos)
                    .HasForeignKey(d => d.IdReceitCompl)
                    .HasConstraintName("FK_RECEITA");
            });

            modelBuilder.Entity<Cupon>(entity =>
            {
                entity.HasKey(e => e.IdCupom)
                    .HasName("PK__CUPONS__96FBC323F8DE5CB3");

                entity.ToTable("CUPONS");

                entity.Property(e => e.IdCupom)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_CUPOM");

                entity.Property(e => e.CodigoCupom)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_CUPOM");

                entity.Property(e => e.Filial).HasColumnName("FILIAL");

                entity.Property(e => e.NomeCupom)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_CUPOM");

                entity.Property(e => e.TipoDesconto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_DESCONTO");

                entity.Property(e => e.ValorDesconto)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("VALOR_DESCONTO");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__EMPRESA__E30DF09C9895B4BE");

                entity.ToTable("EMPRESA");

                entity.Property(e => e.IdEmpresa)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_EMPRESA");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BAIRRO");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CIDADE");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Coordenadas)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("COORDENADAS");

                entity.Property(e => e.DataCad)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_CAD");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Filial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FILIAL");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOGRADOURO");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.Pais)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PAIS");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCIA");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONE");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__M0002_END__18DD1088F2AC9B9E").HasName("ID_ENDERECO");

                entity.ToTable("M0002_END");

                entity.Property(e => e.IdEndereco)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_ENDERECO");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BAIRRO");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CIDADE");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPLEMENTO");

                entity.Property(e => e.Coordenadas)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("COORDENADAS");

                entity.Property(e => e.DELETE)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("D_E_L_E_T_E_");

                entity.Property(e => e.DataCad)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_CAD");

                entity.Property(e => e.Filial)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FILIAL");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOGRADOURO");

                entity.Property(e => e.Longitude)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Numero)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO");

                entity.Property(e => e.Pais)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PAIS");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("REFERENCIA");

                entity.Property(e => e.TaxaEntrega)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("TAXA_ENTREGA");
            });

            modelBuilder.Entity<FormaPagamento>(entity =>
            {
                entity.HasKey(e => e.IdPagamento)
                    .HasName("PK__FORMA_PA__F3C896DBC65EDD1F");

                entity.ToTable("FORMA_PAGAMENTO");

                entity.Property(e => e.IdPagamento)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PAGAMENTO");

                entity.Property(e => e.ContaBancaria)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CONTA_BANCARIA");

                entity.Property(e => e.Filial).HasColumnName("FILIAL");

                entity.Property(e => e.NomePagamento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NOME_PAGAMENTO");

                entity.Property(e => e.Taxa)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("TAXA");

                entity.Property(e => e.TipoPagamento)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_PAGAMENTO");
            });

            modelBuilder.Entity<Motoboy>(entity =>
            {
                entity.HasKey(e => e.IdMotob)
                    .HasName("PK__MOTOBOY__CAD9AF0A4029863C");

                entity.ToTable("MOTOBOY");

                entity.Property(e => e.IdMotob)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_MOTOB");

                entity.Property(e => e.Filial).HasColumnName("FILIAL");

                entity.Property(e => e.Moto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MOTO");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.Placa)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PLACA");

                entity.Property(e => e.Taxa)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("TAXA");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("VALOR");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPed)
                    .HasName("PK__PEDIDOS__20AFE2401F43027C");

                entity.ToTable("M0007_PED");

                entity.Property(e => e.IdPed)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PED");

                entity.Property(e => e.DELETE)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("D_E_L_E_T_E_");

                entity.Property(e => e.DatPed)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_PED");

                entity.Property(e => e.DataDespacho)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_DESPACHO");

                entity.Property(e => e.DataFim)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_FIM");

                entity.Property(e => e.DescontoPedido)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("DESCONTO_PEDIDO");

                entity.Property(e => e.Filial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FILIAL");

                entity.Property(e => e.IdPedCli).HasColumnName("ID_PED_CLI");

                entity.Property(e => e.IdPedCompl).HasColumnName("ID_PED_COMPL");

                entity.Property(e => e.IdPedEnder).HasColumnName("ID_PED_ENDER");

                entity.Property(e => e.IdPedPag).HasColumnName("ID_PED_PAG");

                entity.Property(e => e.IdPedProd).HasColumnName("ID_PED_PROD");

                entity.Property(e => e.Obs)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OBS");

                entity.Property(e => e.Plataforma)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PLATAFORMA");

                entity.Property(e => e.TaxaPedido)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("TAXA_PEDIDO");

                entity.Property(e => e.TotalPedido)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("TOTAL_PEDIDO");

                entity.Property(p => p.IdPedCli)
                    .HasColumnName("ID_PED_CLI");

                entity.Property(p => p.IdPedCompl)
                    .HasColumnName("ID_PED_COMPL");

                entity.Property(d => d.IdPedEnder)
                    .HasColumnName("ID_PED_ENDER");

                entity.Property(p => p.IdPedPag)
                    .HasColumnName("ID_PED_PAG");

                entity.Property(d => d.IdPedProd)
                    .HasColumnName("ID_PED_PROD");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                  .HasName("PK__M0004_PRO__18DD1088F2AC9B9E").HasName("ID_PROD");

                entity.ToTable("M0004_PRO");

                entity.Property(e => e.IdProd).HasColumnName("ID_PROD");
                entity.Property(e => e.CODEMP).HasColumnName("CODEMP");
                
                                entity.Property(e => e.CODFIL).HasColumnName("CODFIL");

                entity.Property(e => e.CategProd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CATEG_PROD");

                entity.Property(e => e.CodIntegrador)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COD_INTEGRADOR");

                entity.Property(e => e.DELETE)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("D_E_L_E_T_");

                entity.Property(e => e.DatCad)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CAD");

                entity.Property(e => e.Filial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FILIAL");

                entity.Property(e => e.Foto).HasColumnName("FOTO");

                entity.Property(e => e.IdProdCompl).HasColumnName("ID_PROD_COMPL");

                entity.Property(e => e.IdProdReceita).HasColumnName("ID_PROD_RECEITA");

                entity.Property(e => e.NomeProd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME_PROD");

                entity.Property(e => e.SubcategProd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SUBCATEG_PROD");

                entity.Property(e => e.ValorCusto)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("VALOR_CUSTO");

                entity.Property(e => e.ValorVenda)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("VALOR_VENDA");

                entity.HasOne(d => d.IdProdComplNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdProdCompl)
                    .HasConstraintName("FK_ID_COMPLEMENTO");

                entity.HasOne(d => d.IdProdReceitaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdProdReceita)
                    .HasConstraintName("FK_ID_RECEITA");
            });

            modelBuilder.Entity<Receitum>(entity =>
            {
                entity.HasKey(e => e.IdReceita)
                    .HasName("PK__RECEITA__3BE00650CF49CD8C");

                entity.ToTable("RECEITA");

                entity.Property(e => e.IdReceita)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_RECEITA");

                entity.Property(e => e.DELETE)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("D_E_L_E_T_E_");

                entity.Property(e => e.DatCad)
                    .HasColumnType("datetime")
                    .HasColumnName("DAT_CAD");

                entity.Property(e => e.Filial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FILIAL");

                entity.Property(e => e.NomeReceita)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME_RECEITA");

                entity.Property(e => e.QntdReceita)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("QNTD_RECEITA");
            });

            modelBuilder.Entity<RegistroOcorrencium>(entity =>
            {
                entity.HasKey(e => e.IdRegistro)
                    .HasName("PK__REGISTRO__C7B81E684044752C");

                entity.ToTable("REGISTRO_OCORRENCIA");

                entity.Property(e => e.IdRegistro)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_REGISTRO");

                entity.Property(e => e.DataOcorrido)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DATA_OCORRIDO");

                entity.Property(e => e.DataRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_REGISTRO");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRICAO");

                entity.Property(e => e.Filial).HasColumnName("FILIAL");

                entity.Property(e => e.IdOcorrCli).HasColumnName("ID_OCORR_CLI");

                entity.Property(e => e.IdOcorrPed).HasColumnName("ID_OCORR_PED");

                entity.Property(e => e.Protocolo).HasColumnName("PROTOCOLO");

                entity.Property(e => e.SubtipoOcorrencia)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SUBTIPO_OCORRENCIA");

                entity.Property(e => e.TipoOcorrencia)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TIPO_OCORRENCIA");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.IdOcorrCliNavigation)
                    .WithMany(p => p.RegistroOcorrencia)
                    .HasForeignKey(d => d.IdOcorrCli)
                    .HasConstraintName("FK_OCORRENCIA_CLIENTE");

                
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__91136B90E9E3376E");

                entity.ToTable("M0003_USR");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_USUARIO");

                entity.Property(e => e.Comissao)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("COMISSAO");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.DELETE)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("D_E_L_E_T_E_");

                entity.Property(e => e.DataCad)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_CAD");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Filial)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FILIAL");

                entity.Property(e => e.LoginUsuario)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN_USUARIO");

                entity.Property(e => e.Nivel).HasColumnName("NIVEL");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.SenhaPass)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SENHA_PASS");

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
