namespace UAS.UI.CustomAuthorize
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AllowAnonymousActionAttribute : Attribute
    {
    }
}
