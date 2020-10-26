using System;

namespace MarketStore
{
    class Program
    {

        static void Main(string[] args)
        {
            Cards gold = new Gold("10/26/2020");
            Client rober = new Client("Stojan", "Stojadinovic", "23.2.1999","255255", gold);
            MarketStore pawnShop = new MarketStore(rober);
            pawnShop.Purchaseitem();

            Cards silver = new Silver("10/26/2020");
            Client Mileva = new Client("Mileva", "Mojic", "23.2.1999", "255255", silver);
            MarketStore pawnShopMaster = new MarketStore(Mileva);

            Cards bronze = new Bronze("10/26/2020");
            Client roberti = new Client("Stojan", "Stojadinovic", "23.2.1999", "255255", bronze);
            MarketStore pawnShopMasterElite = new MarketStore(roberti);


            Console.ReadLine();
        }
    }
}
