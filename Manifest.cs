using OrchardCore.Modules.Manifest;

[assembly: Module(
    Author = "Etch UK",
    Category = "Content Management",
    Description = "Blocks module enables content items to have a block based editor.",
    Name = "Blocks",
    Version = "$(VersionNumber)",
    Website = "https://etchuk.com"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Blocks",
    Name = "Blocks",
    Description = "Blocks module enables content items to have a block based editor.",
    Dependencies = new string[] { "Etch.OrchardCore.Blocks.EditorJS" },
    Category = "Content"
)]

[assembly: Feature(
    Id = "Etch.OrchardCore.Blocks.EditorJS",
    Name = "Editor.js",
    Description = "Makes Editor.js available as an editor for blocks.",
    Dependencies = new string [] { "OrchardCore.Media" },
    Category = "Content"
)]