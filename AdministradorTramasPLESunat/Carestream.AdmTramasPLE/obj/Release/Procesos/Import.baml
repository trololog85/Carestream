   M S B A M L   `   `   `  ����   Carestream.AdmTramasPLE-    'Carestream.AdmTramasPLE.Procesos.Import   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Registro de Información��$	��500��$	��748��.��� .+��� .+��� $��Archivos��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��720��.���  � RowDefinitions �� $
��auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��auto ��� $
��auto ��� $
��Auto ��� $
��Auto ��� $
��auto ��� $
��auto �.+��� -   $��LblAnio��$��0��$��0��$��Año:��$��5,2,5,5q�$��5,2,5,5q��� -   $��TxtAnio��$
��Left=�$��0��$��1��$��80��$��23��$��5,5,5,2q��� -   $��LblMes��$��0��$��2��$
��Mes:��$��5,2,5,5q�$��5,2,5,5q��� -   $��CmbMes��$
��Left=�$��0��$��3��$��23��$	��5,2q�$	��150�� �� DisplayMemberPath$ Nombre�� �� SelectedValuePath$
 sCod������ �� -   $��LblEstructura��$��0��$��4��$��Libro:��$��5,2,5,5q�$��5,2,5,5q��� -   $��
CmbArchivo��$
��Left=�$��0��$��5��$��23��$��5,4,0,4q�$	��156��$ Id��$ Nombre������ �� -   $��
lblVersion��$��0��$��6��$��	Versión:��$��5,2,5,5q�$��5,2,5,5q��� -	   $��
CmbVersion��$
��Left=�$��0��$��7��$��23��$	��5,2q�$��80��$ Nombre��$
 sCod������ �� $��Información General��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��720��.���  �� $
��auto ��� $
��auto � �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -
   $��	LblNroRuc��$��0��$��0��$��N° RUC:��$��5,2,5,5q�$��5,2,5,5q��� -   $��	TxtNroRuc��$
��Left=�$��0��$��1��$	��180��$��23�� �� 	MaxLength$ 10��$��5,5,5,2q�.����
� .���  � Color$ Black��� $ 	#33399155��.���� -   $��LblOpe��$��0��$��2��$��Indicador de Operaciones:��$��5,2,5,5q�$��5,2,5,5q��� -   $��CmbIndicadorOpe��$
��Left=�$��0��$��3��$��23��$	��5,2q�$	��150��$	 Cod��$ Nombre������ �� -   $��
LblContReg��$��1��$��0��$��Contenido Registro:��$��5,2,5,5q�$��5,2,5,5q��� -   $��CmbContenidoLib��$
��Left=�$��1��$��1��$��23��$	��5,2q�$	��180��$	 Cod��$ Nombre������ �� -   $��LblIndMoneda��$��1��$��2��$��Indicador Moneda:��$��5,2,5,5q�$��5,2,5,5q��� -   $��	CmbMoneda��$
��Left=�$��1��$��3��$��23��$	��5,2q�$	��150��$
 sCod��$ Nombre������ �� $��Carga de Archivo��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��720��.���  �� $
��auto ��� $
��auto � �� $
��auto ��� $
��auto ��� $
��auto �.+��� -   $��	BtnSelect��$��0��$��0��$	��...��$��23��$��30���� -    ��Name$ TxTRuta��$
��Left=�$��0��$��1��$	��400��$��23��$��5,5,5,2q��� -   $��
BtnGuardar��$��0��$��2��$��90��$��26��$��5,5,5,5q�$
��Left=�����  �� Orientation$ 
Horizontal=�.+��� $��Cargar��$��3,3,3,3q��� $&�� /Recursos/Iconos/file_upload.png���� -   $��LblProgress��$��1��$��0��$��	Progreso:��$��5,2,5,5q�$��5,2,5,5q�� -   $��PrgBarImport��$��1��$��1��$	��396��$��23��$
��Left=�$��5,5,0,2q��� -   $��LblMsgProgress��$��1��$��2��$�� ��$��5,2,5,5q�$��5,2,5,5q��� $��Registro de Cargas��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$ ��720                       ��.��� .+�&   System.Windows.Controls.DataGrid  -   $��GridLibroLog��	   AutoGenerateColumns	 .  $��5,5,5,5q�
   CanUserAddRows
 .     CanUserResizeColumns .     SelectionMode$ Single=�   
IsReadOnly . $
��auto��"   VerticalScrollBarVisibility$ Visible=�$	��160��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ id�  $ Hidden=� �� $ idLibro�     Header$ Nombre��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 $ Visible=� �� $ NombreLibro�  $ Fecha ��$	 150 $ Visible=� �� $ sFechaCarga�  $ 
Registros ��$	 150 $ Visible=� �� $ 	Registros�4  .System.Windows.Controls.DataGridTemplateColumn  $ Generar Archivo ��$	 130 $ Visible=�   CellTemplate �� .R��� $��20��$��20��$��/Recursos/Iconos/file.png��  $ 
Registros ��$	 150 $ Hidden=� �� $ tipolog�  $ 
Registros ��$	 150 $ Hidden=� �� $ indicadorlibro�  $ 
Registros ��$	 150 $ Hidden=� �� $ indicadormoneda�  $ 
Registros ��$	 150 $ Hidden=� �� $ indicadoroperacion�  $ 
Registros ��$	 150 $ Hidden=� �� $	 RUC�  $ Errores ��$	 150 $ Hidden=� �� $ Errores�