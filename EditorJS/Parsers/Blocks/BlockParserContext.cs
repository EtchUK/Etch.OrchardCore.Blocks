using Etch.OrchardCore.Blocks.Fields;
using OrchardCore.DisplayManagement;
using OrchardCore.Liquid;

namespace Etch.OrchardCore.Blocks.EditorJS.Parsers.Blocks
{
    public class BlockParserContext
    {
        public BlockField Field { get; set; }
        public ILiquidTemplateManager LiquidTemplateManager { get; set; }
        public IShapeFactory ShapeFactory { get; set; }
    }
}
