namespace URLShortening.DAL.Parameters
{
    public class ConstantParameters
    {
        //This value can be given via the parameter. It was set directly because it said 6 on the pdf.
        public const int MaxCharHashLength = 6;
        //Url code source
        public const string CodeSource = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    }
}
