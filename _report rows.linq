<Query Kind="Expression" />

string.Join("\n", Enumerable.Range(1,200).Select(x => 
$@"          <tr style=""%%Counterparty Won Against {x} - Style%%"">
                <td style=""width:75px"" align=""left""></td>
                <td align=""right""><a href=""%%URL - Account Page 01 - Counterparty Won Against {x}%%"">%%Counterparty Won Against {x} - Account ID Key%%</a></td>
                <td align=""right"">%%Counterparty Won Against {x} - Amount Format:""+#,##0&nbsp\;USD;-#,##0&nbsp\;USD;&nbsp\;""%%</td>
            </tr>"))