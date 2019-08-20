using Etch.OrchardCore.EditorJS.Parsers.Blocks;
using Etch.OrchardCore.EditorJS.Parsers.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Etch.OrchardCore.EditorJS.Parsers
{
    public class BlocksParser : IBlocksParser
    {
        #region Properties

        private IDictionary<string, IBlockParser> _parsers = new Dictionary<string, IBlockParser>
        {
            { "paragraph", new ParagraphBlockParser() }
        };

        #endregion

        #region Implementation

        public string ToHtml(string data)
        {
            var html = string.Empty;
            var blocks = JsonConvert.DeserializeObject<EditorBlocks>(data);

            foreach (var block in blocks.Blocks)
            {
                if (!_parsers.ContainsKey(block.Type))
                {
                    continue;
                }

                html += $"{_parsers[block.Type].Render(block)}{Environment.NewLine}{Environment.NewLine}";
            }

            return html;
        }

        #endregion
    }

    public interface IBlocksParser
    {
        string ToHtml(string data);
    }
}
