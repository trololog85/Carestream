   M S B A M L   `   `   `  ����  Carestream.AdmTramasPLE3    -Carestream.AdmTramasPLE.Mantenimientos.Libros   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Libros��5   	   $	��440��6   $	��520��6%   .��5      � .+�5   
   �� .+�5      �� $��Datos Libro��6   $
��Left=�6,   $��	10,10,0,0q�6G   $	��Top=�6Z   $	��150��6r   $	��492��6   .��5      �  � RowDefinitions 5	      �� 5
      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(    � ColumnDefinitions 5      �� 5      $
��auto �6+   �� 5      $
��auto �6+   .+�5      �� -   5        $��	LblNombre��5      $��0��6-   $��0��6:   $��Nombre:��6J   $��5,5,5,2q�6\   $��5,5,5,2q�6m   6�   �� 5      -   5        $��	TxTNombre��5      $
��Left=�6/   $��0��6J   $��1��6W   $	��150��6g   $��23��6s   $��5,5,5,2q�6    �� MaxLines$ 1��6�    �� 	MaxLength$ 50��6�   6�   �� 5      -   5        $��	LblCodigo��5      $��1��6-   $��0��6:   $��Código:��6J   $��5,2,5,5q�6\   $	��5,2q�6m   6}   �� 5      -   5        $��	TxTCodigo��5   9   $
��Left=�6   $��1��6J   $��1��6W   $	��100��6g   $��23��6s   $	��5,2q�6   6�   �� 5      -   5        $��LblEstructura��5      $��2��61   $��0��6>   $��Estructura:��6N   $��5,2,5,5q�6d   $��5,2,5,5q�6u   6�   �� 5      -   5        $��CmbEstructura��5      $
��Left=�64   $��2��6O   $��1��6\   $��23��6l   $	��5,2q�6x   $	��150��6�   6�   �� 5      -   5        $��
BtnGuardar��5      $��3��6/   $��0��6<   $��2��6L   $��90��5      $��27��6$   $��5,5,5,5q�61   $
��Left=�6B   ��5      �� 5       �� Orientation$ 
Horizontal=�6)   .+�5   "   �� $��Guardar��6,   $��3,3,3,3q�6;   �� 5   "   $��/Recursos/Iconos/save.png��6(   6M   5      5!      5"      5#      �� 5$      $��Libros��6   $
��auto��6'   $	��492��66   .��5%      � .+�5&      &   System.Windows.Controls.DataGrid  -	   5        $��
GridLibros��5&   ;      AutoGenerateColumns .  $��5,5,5,5q�6M      CanUserAddRows .     CanUserResizeColumns .  	   SelectionMode$	 Single=�5)      
   
IsReadOnly
 .    Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *id+6H     5-         Header$ Nombre��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6A   $ Visible=�6h    6M   �� *nombre+6h     5.      $ Código��61   $	 150 6A   $ Visible=�6h    6M   �� *codigo+6h   50      51      52      53      54      55      