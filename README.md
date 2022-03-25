# Etch.OrchardCore.Blocks

Orchard Core module providing WYSIWYG editor via [Editor.js](https://editorjs.io/).

## Build Status

[![Build Status](https://secure.travis-ci.org/etchuk/Etch.OrchardCore.Blocks.png?branch=master)](http://travis-ci.org/etchuk/Etch.OrchardCore.Blocks) [![NuGet](https://img.shields.io/nuget/v/Etch.OrchardCore.Blocks.svg)](https://www.nuget.org/packages/Etch.OrchardCore.Blocks)

## Orchard Core Reference

This module is referencing a stable build of Orchard Core ([`1.3.0`](https://www.nuget.org/packages/OrchardCore.Module.Targets/1.3.0)).

## Installing

This module is available on NuGet. Add a reference to your Orchard Core web project via the NuGet package manager. Search for "Etch.OrchardCore.Blocks", ensuring include prereleases is checked.

Alternatively, [download the source](https://github.com/etchuk/Etch.OrchardCore.Blocks/archive/master.zip) or clone the repository to your local machine. Add the project to your solution that contains an Orchard Core project and add a reference to Etch.OrchardCore.Blocks.

## Usage

Enable the "Blocks" feature, which will add a new "Block Body" part and a "Block Field" content field. Both the part & field will allow content editors to use a block editor driven by [Editor.js](https://editorjs.io/).

Each block is represented by a shape whose template can be overridden in a custom module/theme. For example, the pargraph block is represented by a shape named `Block__Paragraph` that can be overridden with a template named `Block-Paragraph`.
