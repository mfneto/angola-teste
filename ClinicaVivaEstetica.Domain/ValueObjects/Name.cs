namespace ClinicaVivaEstetica.Domain.ValueObjects
{
    public class Name
    {
        public string Text { get; private set; }

        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new FieldShouldNotBeEmptyException("O 'Name' do cliente é obrigatório");

            this.Text = text;
        }

        public override string ToString()
        {
            return Text.ToString();
        }

        public static implicit operator Name(string text)
        {
            return new Name(text);
        }
    }
}
