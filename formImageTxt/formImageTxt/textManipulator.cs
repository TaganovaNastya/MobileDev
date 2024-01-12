namespace formImageTxt
{
    internal class textManipulator
    {
        private readonly RichTextBox richTextBox;
        private Font currentFont;

        public textManipulator(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
            this.currentFont = richTextBox.Font;
        }

        public void SetText(string text)
        {
            richTextBox.Text = text;

            
        }

        public void ChangeFontColor(Color color)
        {
            richTextBox.SelectionStart = 0;
            richTextBox.SelectionLength = richTextBox.Text.Length;
            richTextBox.SelectionColor = color;
        }

        public void ChangeFont(Font font)
        {
            currentFont = font; // Обновляем текущий шрифт
            richTextBox.SelectionStart = 0;
            richTextBox.SelectionLength = richTextBox.Text.Length;
            richTextBox.SelectionFont = font;
        }
    }
}
