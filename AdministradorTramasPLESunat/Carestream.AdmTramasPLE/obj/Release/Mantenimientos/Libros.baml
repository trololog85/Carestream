   M S B A M L   `   `   `  ����   Carestream.AdmTramasPLE3    -Carestream.AdmTramasPLE.Mantenimientos.Libros   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Libros��$	��440��$	��520��.��� .+��� .+��� $��Datos Libro��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��150��$	��492��.���  � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��auto ��� $
��auto �.+��� -   $��	LblNombre��$��0��$��0��$��Nombre:��$��5,5,5,2q�$��5,5,5,2q��� -   $��	TxTNombre��$
��Left=�$��0��$��1��$	��150��$��23��$��5,5,5,2q� �� MaxLines$ 1�� �� 	MaxLength$ 50���� -   $��	LblCodigo��$��1��$��0��$��Código:��$��5,2,5,5q�$	��5,2q��� -   $��	TxTCodigo��$
��Left=�$��1��$��1��$	��100��$��23��$	��5,2q��� -   $��LblEstructura��$��2��$��0��$��Estructura:��$��5,2,5,5q�$��5,2,5,5q��� -   $��CmbEstructura��$
��Left=�$��2��$��1��$��23��$	��5,2q�$	��150���� -   $��
BtnGuardar��$��3��$��0��$��2��$��90��$��27��$��5,5,5,5q�$
��Left=�����  �� Orientation$ 
Horizontal=�.+��� $��Guardar��$��3,3,3,3q��� $��/Recursos/Iconos/save.png���� $��Libros��$
��auto��$	��492��.��� .+�&   System.Windows.Controls.DataGrid  -	   $��
GridLibros��   AutoGenerateColumns .  $��5,5,5,5q�   CanUserAddRows .     CanUserResizeColumns .  	   SelectionMode$	 Single=�
   
IsReadOnly
 .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *id+     Header$ Nombre��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 $ Visible=� �� *nombre+  $ Código��$	 150 $ Visible=� �� *codigo+