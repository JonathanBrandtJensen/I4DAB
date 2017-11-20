using HandIn2._2.Collections.ContactCollection;

namespace HandIn2._2
{
    public interface IMenuTextFormatter
    {
        void CenteredHeader(string text);
        void MenuItem(string itemName, string text);
        void PrintContact(Contact c);
        void PrintContact(int key, Contact c);
        void PrintAddresses(Contact c);
        void PrintPhonenumber(Contact c);
        void PrintEmails(Contact c);
    }
}