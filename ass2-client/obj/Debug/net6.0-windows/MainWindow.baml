   M S B A M L   `   `   `  ????F  Bass2-client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ass2_clientass2_client  5   	       ass2_client.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ass2_client     5   	   -   5          ?Name$  salesWindow??5   	    ? Title$ Sales??5   	   $	??450??6   $	??800??6$    ? WindowStyle$ 
ToolWindow=?60    ? 
ResizeMode$ NoResize=?6I    ? SizeToContent$ WidthAndHeight=?6_   $	??100??6~   $	??100??6?    ? WindowStartupLocation$ CenterScreen=?6?   ???	#FF254F68.??5	      ?? .+?5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ saleGrid??5
         RowHeaderWidth$ 0Q?6}      GridLinesVisibility$
 None=?6?   $??0,0,0,0q?6?   	   CanUserAddRows$	 False??6?   
   CanUserDeleteRows$
 False??6?      CanUserResizeRows$ False??6?   $??
10,10,10,0q?6  ??6P   Z? ??6g   Z? 6  ]? 5   
   $
??True??6   .+?5      ?? -   5        $??Complete Transaction??5      $	??NaN??64   $??
0,10,10,10q?6@   ???	#1FFFFFFF$??0,0,0,0q?6k   
???????$??10,10,10,10q?6?   $??Right=?6?   6?   ]? 5      ???	#1F000000$??10,10,10,10q?6/   .+?5      ]? $??Center=?6   $??Center=?69   .+?5      ?? $??Total:??6   $??
10,10,2,10q?6-   ?? 5      -   5         ??Name$ labelTot??5      $??0??6.   $??
2,10,10,10q?6:   5      5      5      5      5      