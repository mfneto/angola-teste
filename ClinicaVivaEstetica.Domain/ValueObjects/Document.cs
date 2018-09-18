namespace ClinicaVivaEstetica.Domain.ValueObjects
{
    public class Document
    {
        public string Text { get; private set; }

        public Document(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new FieldShouldNotBeEmptyException("O 'Documento' do cliente é obrigatório");

            this.Text = text;
        }

        public override string ToString()
        {
            return Text.ToString();
        }

        public static implicit operator Document(string text)
        {
            return new Document(text);
        }
    }
}