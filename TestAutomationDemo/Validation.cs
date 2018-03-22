using TestAutomationDemo.Validations;

namespace TestAutomationDemo
{
    public class Validation
    {
        Pages pages;

        HomepageValidation homepage;
        AuthenticationValidation authentication;
        CreateAnAccountValidation createAnAccount;
        CatalogValidation catalog;
        ProductValidation product;
        CartSummaryValidation cartSummary;
        MyAccountValidation myAccount;

        public Validation(Pages pages) => this.pages = pages;

        public HomepageValidation Homepage => homepage ?? (homepage = new HomepageValidation(pages.Homepage));
        public AuthenticationValidation Authentication => authentication ?? (authentication = new AuthenticationValidation(pages.Authentication));
        public CreateAnAccountValidation CreateAnAccount => createAnAccount ?? (createAnAccount = new CreateAnAccountValidation(pages.CreateAnAccount));
        public CatalogValidation Catalog => catalog ?? (catalog = new CatalogValidation(pages.Catalog));
        public ProductValidation Product => product ?? (product = new ProductValidation(pages.Product));
        public CartSummaryValidation CartSummary => cartSummary ?? (cartSummary = new CartSummaryValidation(pages.CartSummary));
        public MyAccountValidation MyAccount => myAccount ?? (myAccount = new MyAccountValidation(pages.MyAccount));
    }
}
