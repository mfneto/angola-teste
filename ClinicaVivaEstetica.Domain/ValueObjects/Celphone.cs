namespace ClinicaVivaEstetica.Domain.ValueObjects
{
    public class Celphone
    {
        public string Text { get; private set; }

        public Celphone(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new FieldShouldNotBeEmptyException("O 'Celular' do cliente é obrigatório");

            this.Text = text;
        }

        public override string ToString()
        {
            return Text.ToString();
        }

        public static implicit operator Celphone(string text)
        {
            return new Celphone(text);
        }
    }
}