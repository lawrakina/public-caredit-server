using System.Xml;
using CarEdit_Server.Models;
using CarEdit_Server.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace CarEdit_Server.Services;

public class MenuService(ApplicationContext context)
{
    public async Task AddAsync(Plugin menuItem)
    {
        context.Plugins.Add(menuItem);
        await context.SaveChangesAsync();
    }

    public async Task UpdateMenuItemAsync(Plugin menuItem)
    {
        var existingMenuItem = await context.Plugins.FindAsync(menuItem.Id);
        if (existingMenuItem != null)
        {
            existingMenuItem.Name = menuItem.Name;
            existingMenuItem.Value = menuItem.Value;
            existingMenuItem.ParentId = menuItem.ParentId;
            existingMenuItem.Icon = menuItem.Icon;
            existingMenuItem.IsVisible = menuItem.IsVisible;

            context.Plugins.Update(existingMenuItem);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteMenuItemAsync(int id)
    {
        var menuItem = await context.Plugins.FindAsync(id);
        if (menuItem != null)
        {
            context.Plugins.Remove(menuItem);
            await context.SaveChangesAsync();
        }
    }

    public async Task<Plugin> GetMenuItemByIdAsync(int id)
    {
        return await context.Plugins
            .Include(m => m.Children)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Plugin>> GetAllMenuItemsAsync()
    {
        return await context.Plugins
            .Include(m => m.Children)
            .ToListAsync();
    }

    public async Task<string> GenerateXmlFromPluginsAsync()
    {
        var plugins = await context.Plugins
            .Include(p => p.Children)
            .ToListAsync();

        var doc = new XmlDocument();
        var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        var root = doc.DocumentElement;
        doc.InsertBefore(xmlDeclaration, root);

        var treeViewElement = doc.CreateElement(string.Empty, "TreeView", string.Empty);
        treeViewElement.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
        treeViewElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
        // treeViewElement.SetAttribute("ExpandAnimation", "None");
        // treeViewElement.SetAttribute("LineStyle", "Solid");
        // treeViewElement.SetAttribute("ItemHeight", "24");
        // treeViewElement.SetAttribute("TreeIndent", "15");
        // treeViewElement.SetAttribute("ShowLines", "true");
        // treeViewElement.SetAttribute("ShowRootLines", "false");
        // treeViewElement.SetAttribute("AllowDrop", "true");
        // treeViewElement.SetAttribute("LineStyle", "Dash");
        // treeViewElement.SetAttribute("LineColor", "204; 204; 204");

        doc.AppendChild(treeViewElement);

        foreach (var plugin in plugins.Where(p => p.ParentId == null))
        {
            AppendPluginNode(doc, treeViewElement, plugin);
        }

        var settings = new XmlWriterSettings
        {
            Async = true,
            Indent = true,
            IndentChars = "\t"
        };

        await using var stringWriter = new StringWriter();
        await using var xmlTextWriter = XmlWriter.Create(stringWriter, settings);
        doc.WriteTo(xmlTextWriter);
        await xmlTextWriter.FlushAsync();
        return stringWriter.GetStringBuilder().ToString();
    }

    private void AppendPluginNode(XmlDocument doc, XmlElement parentElement, Plugin plugin)
    {
        var nodeElement = doc.CreateElement(string.Empty, "Nodes", string.Empty);
        nodeElement.SetAttribute("Text", plugin.Value);
        nodeElement.SetAttribute("Name", plugin.Name);
        nodeElement.SetAttribute("Font", "Microsoft Sans Serif, 10pt");

        parentElement.AppendChild(nodeElement);

        foreach (var child in plugin.Children)
        {
            AppendPluginNode(doc, nodeElement, child);
        }
    }
}