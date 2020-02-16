namespace VeeamTest.Controls.IActions
{
    public interface IReadable
    {
        string Read();
        IReadable Read(out string text);
    }
}
