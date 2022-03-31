using System.Collections.Generic;
using System;

namespace Pasqliecli.Frontend.Dto;

public class View
{
    public List<List<string>> Content { get; init; }

    public View(List<List<string>> content)
    {
        this.Content = content;
    }

    public void OutputContent()
    {
        foreach (List<string> rowContent in this.Content)
        {
            string row = "";

            foreach (string field in rowContent)
            {
                if (row != "")
                {
                    row += " ";
                }

                row += field;
            }

            Console.WriteLine(row);
        }
    }
}
