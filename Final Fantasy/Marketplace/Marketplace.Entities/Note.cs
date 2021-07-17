//TODO удалить файл

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Entities
{
    public class Note
    {
        public Note(string text, int id)
        {
            ID = id;
            Text = text;
            CreationDate = DateTime.Now;
        }

        public Note(int id, string text, DateTime creationDate)
        {
            ID = id;
            Text = text;
            CreationDate = creationDate;
        }

        public Note(string text)
        {
            ID = -1;
            Text = text;
            CreationDate = DateTime.Now;
        }

        public int ID { get; private set; }

        public string Text { get; private set; }

        public DateTime CreationDate { get; private set; }

        public void Edit(string newText)
        {
            if (newText == null)
                throw new ArgumentNullException("str", "Text string cannot be null!");

            Text = newText;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
