using SistemaDeComandas.BancoDeDados;
using SistemaDeComandas.Modelos;

namespace comanda.api
{
    public static class InicializarDados
    {
        public static void Semear(ComandaContexto banco) 
        {
            // cardapio
            // SE não tem nenhum CardapioItem
            if(!banco.cardapioItems.Any())
            {
                banco.cardapioItems.AddRange(
                    new CardapioItem()
                    {
                        Descricao = "Bife, Ovo, Presunto, Queijo, Salada",
                        PossuiPreparo = true,
                        Preco = 20.00M,
                        Titulo = "Xis Salada"
                    },

                    new CardapioItem()
                    {
                        Descricao = "Bacon, Queijo, Bife, Alface",
                        PossuiPreparo = true,
                        Preco = 15.00M,
                        Titulo = "Xis Bacon"
                    },

                    new CardapioItem()
                    {
                        Descricao = "Coquinha Gelada hmmm",
                        PossuiPreparo = false,
                        Preco = 10.00M,
                        Titulo = "Coca Cola"
                    }
                ); // ADDRange
            } // IF

            if(!banco.Usuarios.Any())
            {
                banco.Usuarios.AddRange(
                    new Usuario()
                    {
                        Email = "ADM@admin.com",
                        Nome = "Admin",
                        Senha = "Admin123"
                    }
                );
            }

            if (!banco.Mesas.Any())
            {
                banco.Mesas.AddRange(
                    new Mesa { NumeroMesa = 1, SituacaoMesa = 1 },
                    new Mesa { NumeroMesa = 2, SituacaoMesa = 1 },
                    new Mesa { NumeroMesa = 3, SituacaoMesa = 1 },
                    new Mesa { NumeroMesa = 4, SituacaoMesa = 1 }
                );
            }

            if (banco.Comandas.Any())
            {
                var comanda = new Comanda() { NomeCliente = "Rafael", NumeroMesa = 1, SituacaoComanda = 1 };
                banco.Comandas.Add(comanda);

                ComandaItem[] comandaItems =
                {
                    new ComandaItem()
                    {
                        Comanda = comanda,
                        CardapioItemId = 1
                    },

                    new ComandaItem()
                    {
                        Comanda = comanda,
                        CardapioItemId = 2
                    },

                    new ComandaItem()
                    {
                        Comanda = comanda,
                        CardapioItemId = 3
                    }
                };

                if (!banco.ComandaItems.Any())
                {
                    banco.ComandaItems.AddRange(comandaItems);
                };
                var pedidoCozinha = new PedidoCozinha() { Comanda = comanda };
                var pedidoCozinha2 = new PedidoCozinha() { Comanda = comanda };

                PedidoCozinhaItem[] pedidoCozinhaItems =
                {
                    new PedidoCozinhaItem{PedidoCozinha = pedidoCozinha, ComandaItem = comandaItems[0]},
                    new PedidoCozinhaItem{PedidoCozinha = pedidoCozinha2 , ComandaItem =comandaItems[1]}
                };

                banco.PedidoCozinhas.Add(pedidoCozinha);
                banco.PedidoCozinhas.Add(pedidoCozinha2);
                banco.PedidoCozinhaItems.AddRange(pedidoCozinhaItems);
            };
            // INSERT INTO cardapioItem (Columns) VALUES(1, "salsicha")
            banco.SaveChanges();
        }
    }
}
