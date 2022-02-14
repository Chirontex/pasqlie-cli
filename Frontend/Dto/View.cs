using System.Collections.Generic;

namespace Pasqliecli.Frontend.Dto;

public class View
{
    public List<List<string>> Content { get; init; }

    public View(List<List<string>> content)
    {
        this.Content = content;
    }
}
