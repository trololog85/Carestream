   M S B A M L   `   `   `  ����   Carestream.AdmTramasPLE8    2Carestream.AdmTramasPLE.Mantenimientos.Estructuras   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Estructuras��$	��689��$	��700��.��� .+���  �� Orientation$ 
Horizontal=�.+��� .+��� $��Datos Estructura��$
��Left=�$��	10,10,5,0q�$	��Top=�$	��120��$	��300��.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto �.+��� -   $��	LblNombre��$��0��$��0��$��Nombre:��$��5,5,5,2q�$��5,5,5,2q��� -   $��	TxTNombre��$
��Left=�$��0��$��1��$	��150��$��23��$��5,5,5,2q� �� MaxLines$ 1�� �� 	MaxLength$ 50���� -   $��
LblVersion��$��1��$��0��$��	Versión:��$��5,5,5,2q�$��5,5,5,2q��� -   $��
CmbVersion��$
��Left=�$��1��$��1��$��23��$	��5,2q�$��80���� -   $��
BtnGuardar��$��3��$��0��$��2��$��90��$��27��$��5,5,5,5q�$
��Left=����� $ 
Horizontal=�.+��� $��Guardar��$��3,3,3,3q��� $��/Recursos/Iconos/save.png���� $��Estructuras��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��260��$	��300��.��� .+�&   System.Windows.Controls.DataGrid  -   $��
GridLibros��   AutoGenerateColumns .  $��5,5,5,5q�   CanUserAddRows .     CanUserResizeColumns .  	   SelectionMode$	 Single=�
   
IsReadOnly
 .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *id+  $ Hidden=� �� *nombre+     Header$ Nombre��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 $ Visible=� �� *	version+  $ Version��$ 50 $ Visible=� �� *	version+�� .+��� $��Campos Estructura��$
��Left=�$��	10,10,5,0q�$	��Top=�$	��390��$	��350��.���  �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � �� $
��auto ��� $
��auto �.+��� -   $��BtnAdd��$��0��$��0��$��30��$��27��$��5,5,5,5q�$��Right=����� $ 
Horizontal=�.+��� $"��/Recursos/Iconos/plus_64.png��$��18��$��18���� -   $��	BtnDelete��$��0��$��1��$��30��$��27��$��5,5,5,5q�$
��Left=����� $ 
Horizontal=�.+��� $!��/Recursos/Iconos/Delete.png��$��18��$��18���� -	   $��LblNumCampo��$��1��$��0��$��Nombre:��$��5,5,5,2q�$��5,5,5,2q�$��Right=��� -
   $��TxTNumCampo��$
��Left=�$��1��$��1��$	��150��$��23��$��5,5,5,2q�$ 1��$ 50���� -   $��LblTipoDato��$��2��$��0��$��Tipo:��$��5,5,5,2q�$��5,5,5,2q�$��Right=��� -   $��CmbTipoDato��$
��Left=�$��2��$��1��$��23��$	��5,2q�$	��150���� -   $��	LblInicio��$��3��$��0��$��Inicio:��$��5,5,5,2q�$��5,5,5,2q�$��Right=��� -   $��	TxtInicio��$
��Left=�$��3��$��1��$��50��$��23��$��5,5,5,2q�$ 1��$ 50���� -   $��LblFin��$��4��$��0��$
��Fin:��$��5,5,5,2q�$��5,5,5,2q�$��Right=��� -   $��TxtFin��$
��Left=�$��4��$��1��$��50��$��23��$��5,5,5,2q�$ 1��$ 50���� -   $��LblObligatorio��$��5��$��0��$��Obligatorio:��$��5,5,5,2q�$��5,5,5,2q�$��Right=��� -   $��ChkObligatorioBox��$��5��$��1��$��20��$��Center=�$
��Left=�$��5,5,5,2q�