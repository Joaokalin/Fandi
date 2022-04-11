namespace FandiApi.Modelos.Entidades.Produtos;

public static class ProdutoConsulta
{
    public static IQueryable<Produto> OndeNome(this IQueryable<Produto> consulta, string nome)
    {
        if (string.IsNullOrEmpty(nome)) return consulta;
        return consulta.Where(item => item.Nome == nome);
    }

}