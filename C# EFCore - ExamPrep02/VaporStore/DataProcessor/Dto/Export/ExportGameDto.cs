using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class ExportGameDto
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public GameExDto[] Games { get; set; }
        public int TotalPlayers { get; set; }

    }
}

