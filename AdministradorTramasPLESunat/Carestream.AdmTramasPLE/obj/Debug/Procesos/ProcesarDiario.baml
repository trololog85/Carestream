   M S B A M L   `   `   `  ����R  NCarestream.AdmTramasPLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Carestream.AdmTramasPLE.Procesos Carestream.AdmTramasPLE.Procesos  5   	   5    /Carestream.AdmTramasPLE.Procesos.ProcesarDiario   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Carestream.AdmTramasPLE.Procesos     5   	   -   5          � Title$  ProcesarDiario��5   	   $	��500��6    $	��748��6-    � 
ResizeMode$ NoResize=�6P   .��5	      � .+�5
   
   �� .+�5      �� $��Archivos��6   $
��left=�6)   $��	10,10,0,0q�6D   $	��top=�6W   $
��auto��6o   $	��720��6}   .��5      �  � RowDefinitions 5      �� 5      $
��auto �6(    � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��auto �6+   �� 5      $
��auto �6+   .+�5      �� -   5        $��LblAnio��5      $��0��6+   $��0��68   $��Año:��6H   $��5,2,5,5q�6W   $��5,2,5,5q�6h   �� 5      -   5        $��TxtAnio��5      $
��Left=�6-   $��0��6H   $��1��6U   $��80��6e   $��23��6p   $��5,5,5,2q�6|   �� 5      -   5        $��lblMes��5      $��0��6*   $��2��67   $
��Mes:��6G   $��5,2,5,5q�6V   $��5,2,5,5q�6g   �� 5      -   5        $��TxtMes��5      $
��Left=�6,   $��0��6G   $��3��6T   $��80��6d   $��23��6o   $��5,5,5,2q�6{   5      5      �� 5      $��Archivos Cargados��6   $
��left=�62   $��	10,10,0,0q�6M   $	��top=�6`   $
��auto��6x   $	��720��6�   .��5      �  5      �� 5      $
��auto �6(   �� 5       $
��auto �6(    5"      �� 5#      $
��Auto �6+   �� 5$      $
��Auto �6+   .+�5&      &   System.Windows.Controls.DataGrid  -   5        $��GridLibroLog��5&   X   $��0��6   $��0��6,      AutoGenerateColumns .  $��5,5,5,5q�6l      CanUserAddRows .     CanUserResizeColumns .     SelectionMode$ Single=�5)         
IsReadOnly . $
��auto��5+      "	   VerticalScrollBarVisibility$	 Visible=�6,   $	��160��6R   
   Columns
 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$ id�6M     5.      $ Hidden=�6R    61   �� $ idLibro�6R     5/         Header$ Nombre��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6A   $ Visible=�6r    6M   �� $ NombreLibro�6r     50      $ Fecha ��61   $	 150 6A   $ Visible=�6r    6M   �� $ sFechaCarga�6r     51      $ 
Registros ��61   $	 150 6E   $ Visible=�6t    6Q   �� $ 	Registros�6t     52      $ 
Registros ��61   $	 150 6E   $ Hidden=�6r    6Q   �� $ tipolog�6r     53      $ 
Registros ��61   $	 150 6E   $ Hidden=�6y    6Q   �� $ indicadorlibro�6y     54      $ 
Registros ��61   $	 150 6E   $ Hidden=�6z    6Q   �� $ indicadormoneda�6z     55      $ 
Registros ��61   $	 150 6E   $ Hidden=�6}    6Q   �� $ indicadoroperacion�6}     56      $ 
Registros ��61   $	 150 6E   $ Hidden=�6n    6Q   �� $	 RUC�6n     57      $ Errores ��61   $	 150 6C   $ Hidden=�6p    6O   �� $ Errores�6p   59      �� 5:      -   5        $��
BtnGuardar��5:      $��0��6/   $��1��6<   $��2��6L   $	��Top=�6]   $��90��5;      $��26��6$   $��5,5,5,5q�61   $
��Left=�6B   ��5<      �� 5=       �� Orientation$ 
Horizontal=�6)   .+�5>   "   �� $��Procesar��6,   $��3,3,3,3q�6<   �� 5?   "   $"��/Recursos/Iconos/process.png��6(   6P   5@      5B      � 5C      $��1��6   $��0��6(    5D      �� 5E      $
��auto �6,    5G      �� 5H      $
��Auto �6/   �� 5I      $
��Auto �6/   .+�5K      �� -   5        $��LblProgress��5K       $��0��63   $��0��6@   $��	Progreso:��6P   $��5,2,5,5q�6d   $��5,2,5,5q�6u   � 5L      -	   5        $��PrgBarImport��5L   &   $��0��6:   $��1��6G   $	��396��6W   $��23��6c   $
��Left=�6o   $��5,5,0,2q�6�   5M      5N      5O      �� 5P      $��	Registros��6   $
��left=�6*   $��	10,10,0,0q�6E   $	��top=�6X   $
��auto��6p   $	��720��6~   .��5Q      � .+�5R        -
   5        $��GridRegistros��5R   X   $��0��6   $��0��6,    .  $��5,5,5,5q�6m    .   .  $ Single=�5U       . $
��auto��5W      $	 Visible=�6,   $	��120��6R   
 5X        5Y      $ Hidden=�6M    61   �� $ id�6M     5Z      $ Hidden=�6R    61   �� $ idLibro�6R     5[      $ Nombre��61   $	 200 6A   $ Visible=�6r    6M   �� $ NombreLibro�6r     5\      $ Fecha ��61   $	 150 6A   $ Visible=�6r    6M   �� $ sFechaCarga�6r     5]      $ 
Registros ��61   $	 150 6E   $ Visible=�6t    6Q   �� $ 	Registros�6t     5^      $ 
Registros ��61   $	 150 6E   $ Hidden=�6r    6Q   �� $ tipolog�6r     5_      $ 
Registros ��61   $	 150 6E   $ Hidden=�6y    6Q   �� $ indicadorlibro�6y     5`      $ 
Registros ��61   $	 150 6E   $ Hidden=�6z    6Q   �� $ indicadormoneda�6z     5a      $ 
Registros ��61   $	 150 6E   $ Hidden=�6}    6Q   �� $ indicadoroperacion�6}     5b      $ 
Registros ��61   $	 150 6E   $ Hidden=�6n    6Q   �� $	 RUC�6n     5c      $ Errores ��61   $	 150 6C   $ Hidden=�6p    6O   �� $ Errores�6p   5e      5f      5g      5h      5i      5j      