using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace TripleZeroLabs.Os2
{
    /// <summary>
    /// Fluent builder for OS2-styled context menus.
    ///
    /// Usage:
    ///     element.ContextMenu = Os2ContextMenu.Create()
    ///         .Item("Copy", () => Clipboard.SetText(value))
    ///         .Separator()
    ///         .Item("Open in browser", () => Process.Start(url))
    ///         .Build();
    ///
    /// The returned ContextMenu picks up the implicit OS2 ContextMenu and
    /// MenuItem styles automatically — no extra attributes needed.
    /// </summary>
    public sealed class Os2ContextMenu
    {
        private readonly List<Action<ContextMenu>> _items = new List<Action<ContextMenu>>();

        private Os2ContextMenu() { }

        public static Os2ContextMenu Create() => new Os2ContextMenu();

        public Os2ContextMenu Item(string header, Action onClick)
        {
            _items.Add(menu =>
            {
                var item = new MenuItem { Header = header };
                if (onClick != null)
                    item.Click += (_, __) => onClick();
                menu.Items.Add(item);
            });
            return this;
        }

        public Os2ContextMenu Separator()
        {
            _items.Add(menu => menu.Items.Add(new Separator()));
            return this;
        }

        public ContextMenu Build()
        {
            var menu = new ContextMenu();
            foreach (var add in _items)
                add(menu);
            return menu;
        }
    }
}
