   M S B A M L   `   `   `  ���� R  NCarestream.AdmTramasPLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Carestream.AdmTramasPLE.Procesos Carestream.AdmTramasPLE.Procesos  5    /Carestream.AdmTramasPLE.Procesos.ProcesarDiario   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @local.clr-namespace:Carestream.AdmTramasPLE.Procesos     -     � Title$  ProcesarDiario��$	��500��$	��748�� � 
ResizeMode$ NoResize=�.��� .+��� .+��� $��Archivos��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��720��.���  � RowDefinitions �� $
��auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��auto ��� $
��auto �.+��� -   $��LblAnio��$��0��$��0��$��Año:��$��5,2,5,5q�$��5,2,5,5q��� -   $��TxtAnio��$
��Left=�$��0��$��1��$��80��$��23��$��5,5,5,2q��� -   $��lblMes��$��0��$��2��$
��Mes:��$��5,2,5,5q�$��5,2,5,5q��� -   $��TxtMes��$
��Left=�$��0��$��3��$��80��$��23��$��5,5,5,2q��� $��Archivos Cargados��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��720��.���  �� $
��auto ��� $
��auto � �� $
��Auto ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -   $��GridLibroLog��$��0��$��0��   AutoGenerateColumns .  $��5,5,5,5q�   CanUserAddRows .     CanUserResizeColumns .     SelectionMode$ Single=�   
IsReadOnly . $
��auto��"	   VerticalScrollBarVisibility$	 Visible=�$	��160��
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ id�  $ Hidden=� �� $ idLibro�     Header$ Nombre��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 $ Visible=� �� $ NombreLibro�  $ Fecha ��$	 150 $ Visible=� �� $ sFechaCarga�  $ 
Registros ��$	 150 $ Visible=� �� $ 	Registros�  $ 
Registros ��$	 150 $ Hidden=� �� $ tipolog�  $ 
Registros ��$	 150 $ Hidden=� �� $ indicadorlibro�  $ 
Registros ��$	 150 $ Hidden=� �� $ indicadormoneda�  $ 
Registros ��$	 150 $ Hidden=� �� $ indicadoroperacion�  $ 
Registros ��$	 150 $ Hidden=� �� $	 RUC�  $ Errores ��$	 150 $ Hidden=� �� $ Errores��� -   $��
BtnGuardar��$��0��$��1��$��2��$	��Top=�$��90��$��26��$��5,5,5,5q�$
��Left=�����  �� Orientation$ 
Horizontal=�.+��� $��Procesar��$��3,3,3,3q��� $"��/Recursos/Iconos/process.png��� $��1��$��0�� �� $
��auto � �� $
��Auto ��� $
��Auto �.+��� -   $��LblProgress��$��0��$��0��$��	Progreso:��$��5,2,5,5q�$��5,2,5,5q�� -	   $��PrgBarImport��$��0��$��1��$	��396��$��23��$
��Left=�$��5,5,0,2q��� $��	Registros��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��720��.��� .+�  -
   $��GridRegistros��$��0��$��0�� .  $��5,5,5,5q� .   .  $ Single=� . $
��auto��$	 Visible=�$	��120��
   $ Hidden=� �� $ id�  $ Hidden=� �� $ idLibro�  $ Nombre��$	 200 $ Visible=� �� $ NombreLibro�  $ Fecha ��$	 150 $ Visible=� �� $ sFechaCarga�  $ 
Registros ��$	 150 $ Visible=� �� $ 	Registros�  $ 
Registros ��$	 150 $ Hidden=� �� $ tipolog�  $ 
Registros ��$	 150 $ Hidden=� �� $ indicadorlibro�  $ 
Registros ��$	 150 $ Hidden=� �� $ indicadormoneda�  $ 
Registros ��$	 150 $ Hidden=� �� $ indicadoroperacion�  $ 
Registros ��$	 150 $ Hidden=� �� $	 RUC�  $ Errores ��$	 150 $ Hidden=� �� $ Errores�