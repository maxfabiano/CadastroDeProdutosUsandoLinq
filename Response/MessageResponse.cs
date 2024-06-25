namespace CadastroProdutos.Response;

public record MessageResponse (string Title, string Description, bool Status, object Return);