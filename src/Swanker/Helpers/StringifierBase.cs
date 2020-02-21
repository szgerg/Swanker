namespace Swanker.Helpers
{
    internal abstract class StringifierBase
    {
        protected string tb(int tab)
        {
            var res = "";

            for (int i = 0; i < tab; i++)
                res += "    ";

            return res;
        }

        protected const string rn = "\r\n";
    }
}
