   M S B A M L   `   `   `  ����   Carestream.AdmTramasPLE-    'Carestream.AdmTramasPLE.Procesos.Export   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Generación de Archivos��$	��488��$	��740��.��� .+��� .+��� $��Periodo a Generar��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��710��.���  � RowDefinitions �� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��LblAnio��$��0��$��0��$��Año:��$��5,2,5,5q�$��5,2,5,5q��� -   $��TxtAnio��$
��Left=�$��0��$��1��$��80��$��23��$��5,5,5,2q��� -   $��LblMes��$��0��$��2��$
��Mes:��$��5,2,5,5q�$��5,2,5,5q��� -   $��CmbMes��$
��Left=�$��0��$��3��$��23��$	��5,2q�$	��150�� �� DisplayMemberPath$ Nombre�� �� SelectedValuePath$
 sCod������ �� -   $��
LblVersion��$��0��$��4��$��	Versión:��$��5,2,5,5q�$��5,2,5,5q��� -   $��
CmbVersion��$
��Left=�$��0��$��5��$��23��$	��5,2q�$��80��$ Nombre��$
 sCod������ �� -   $��
BtnGenerar��$��0��$��6��$��90��$��26��$��5,5,5,5q�$
��Left=�����  �� Orientation$ 
Horizontal=�.+��� $��Generar��$��3,3,8,3q��� $��20��$��20��$"��/Recursos/Iconos/process.png���� -	   $��chkSubLibro��$"��Generar Detalle Libro Diario�� d� 	IsChecked$ falseY�$��1��$��0��$��7��$��5,5,5,5q��� $��Ruta de Exportación��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��710��.���  �� $
��auto ��� $
��auto ��� $
��auto � �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -
   $��LblArchivoOrigen��$��0��$��0��$��Archivo Origen:��$��5,2,5,5q�$��5,2,5,5q��� -   $��TxtrutaOrigen��$
��Left=�$��0��$��1��$	��540��$��23��$��5,5,5,2q� �� 
IsReadOnly . $��2���� -   $��LblRuta��$��1��$��0��$��Elegir Ruta:��$��Right=�$��5,2,5,5q�$��5,2,5,5q��� -   $��	BtnSelect��$��1��$��1��$	��...��$��23��$��30��$
��Left=�$��5,5,5,2q��� -   $��TxtRutaExport��$
��Left=�$��1��$��2��$	��500��$��23��$��5,5,5,2q� . �� -   $��LblProgress��$��right=�$��2��$��0��$��	Progreso:��$��5,2,5,5q�$��5,2,5,5q�� -   $��PrgProgreso��$��2��$��1��$	��350��$��2��$��23��$
��Left=�$��5,5,5,2q��� -   $��LblProgreso��$��2��$
��Left=�$��25��$��	330,5,0,0q�$��2��$	��Top=�$	��170���� $��Archivos Generados��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��710��.��&   System.Windows.Controls.DataGrid  -   $��GridLibroLog��   AutoGenerateColumns .  $��5,5,5,5q�	   CanUserAddRows	 .  
   CanUserResizeColumns
 .     SelectionMode$ Single=�   
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�$	��160��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *id+  $ Hidden=� �� *	idLibro+     Header$ Nombre��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 $ Visible=� �� *NombreLibro+  $ Fecha��$	 150 $ Visible=� �� *sFechaGeneracion+  $ Errores��$	 150 $ Visible=� �� *TotalErrores+  $ 	Registros��$ 80 $ Visible=� �� *	Registros+4  .System.Windows.Controls.DataGridTemplateColumn  $ Detalle��$ 80 $ Visible=�   CellTemplate �� .R��� $��20��$��20��$��/Recursos/Iconos/file.png��