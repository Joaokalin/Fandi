using FandiApi.Modelos.DTOS.Produtos;
using FandiApi.Modelos.Entidades.Produtos;
using System.Text.Json;
using Xunit;

namespace FandiApiTest
{
    public class UnitTest1
    {
        [Fact]
        public void ComprarProdutoComEstoque()
        {
            var produto = new Produto() { Nome = "Livro", Qtde_estoque = 10, Valor_unitario = 300 };
            var (status, _) = new ComprarProduto().Comprar(produto, 10);

            Assert.True(status);
            Assert.True(produto.Valor_ultima_venda == 300 * 10);
        }

        [Fact]
        public void ComprarProdutoSemEstoque()
        {
            var produto = new Produto() { Nome = "Livro", Qtde_estoque = 10, Valor_unitario = 300 };
            var (status, _) = new ComprarProduto().Comprar(produto, 15);

            Assert.False(status);
        }


        [Fact]
        public void AtualizarUmProduto()
        {
            var dto = new ProdutoDto() { Nome = "Caderno", Qtde_estoque = 20, Valor_unitario = 240 };
            var produto = new Produto() { Nome = "Livro", Qtde_estoque = 10, Valor_unitario = 300 };

            new AtualizarProduto().Atualizar(produto, dto, 10);
            var produtoParaComparar = new Produto() {Id = 10, Nome = "Caderno", Qtde_estoque = 20, Valor_unitario = 240, Ultima_atualizaçao_em = produto.Ultima_atualizaçao_em };

            Assert.Equal(JsonSerializer.Serialize(produto), JsonSerializer.Serialize(produtoParaComparar));
        }

    }
}