   M S B A M L   `   `   `  ����  Carestream.AdmTramasPLE0    *Carestream.AdmTramasPLE.Procesos.UpdateCUO   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6�   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6�   -   5          � Title$  Actualizar CUO��5   >   $��414.925��6U   $	��860��6f   .��5      � .+�5   
   �� .+�5      �� $��Búsqueda de CUO��6   $
��left=�60   $��	10,10,0,0q�6K   $	��top=�6^   $
��auto��6v   $	��830��6�   .��5      �  � RowDefinitions 5      �� 5      $
��auto �6(   �� 5      $
��auto �6(    � ColumnDefinitions 5
      �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   �� 5      $
��Auto �6+   .+�5      	� $��0��6"   $��0��6/    	� 	GroupName$
 Tipo��6?   $��Ventas��6P    d� 	IsChecked$
 TrueY�6a   $��3,3,8,3q�6r   	� 5      $��0��6"   $��1��6/   $
 Tipo��6?   $��Compras��6P   $ FalseY�6b   $��3,3,8,3q�6t   $y�Hidden=�6�   �� 5      -   5        $��LblBusqueda��5      $��1��6/   $��0��6<   $��5,2,5,5q�6L   $��5,2,5,5q�6]   ��5      �� 5       �� Orientation$ 
Horizontal=�6)   .+�5   "   �� $��20��6(   $��20��63   $!��/Recursos/Iconos/search.png��6?   �� 5   "   $��Ingresar CUO: ��6,   $��3,3,8,3q�6B   5      5      �� 5       -   5        $��TxtCUO��5       $��1��6,   $��1��69   $��80��6I   $��23��6T   ���	#FFF6FB906�   �� 5!      -   5        $��LblAnio��5!      $��1��6+   $��2��68   $��Año:��6H   $��5,2,5,5q�6W   $��5,2,5,5q�6h   �� 5"      -   5        $��TxtAnio��5"      $
��Left=�6-   $��1��6H   $��3��6U   $��80��6e   $��23��6p   $��5,5,5,2q�6|   6�   �� 5#      -   5        $��LblMes��5#      $��1��6*   $��4��67   $
��Mes:��6G   $��5,2,5,5q�6V   $��5,2,5,5q�6g   �� 5$      -   5        $��CmbMes��5$      $
��Left=�6-   $��1��6H   $��5��6U   $��23��6e   $	��5,2q�6q   $	��150��6~    �� DisplayMemberPath$ Nombre��6�    �� SelectedValuePath$
 sCod��6�   ��6�   �� �� 5%      -   5        $��lblCiclo��5%      $��1��6,   $��6��69   $��Ciclo:��6I   $��5,2,5,5q�6Z   $��5,2,5,5q�6k   	� 5&      -	   5        $��
rbApertura��5&   "   $��1��64   $��7��6A   $ Ciclo��6Q   $��Apertura��6c   $
 TrueY�6v   $��3,3,8,3q�6�   	� 5'      -
   5        $��	rbMensual��5'   "   $��1��63   $��8��6@   $ Ciclo��6P   $��Mensual��6b   $ falseY�6t   $��3,3,8,3q�6�   	� 5(      -   5        $��rbCierre��5(   "   $��1��62   $��9��6?   $ Ciclo��6O   $��Cierre��6a   $ falseY�6r   $��3,3,8,3q�6�   5)      5*      �� 5+      $��	Resultado��6   $
��left=�6*   $��	10,10,0,0q�6E   $	��top=�6X   $
��auto��6p   $	��830��6~   .��5,      &   System.Windows.Controls.DataGrid  -   5        $��GridCuoVentas��5,      $��5,5,5,5q�60      CanUserAddRows .  	   CanUserResizeColumns	 .  
   SelectionMode$
 Single=�6u   "   VerticalScrollBarVisibility$ Visible=�6�   $	��240��6�      AutoGenerateColumns .     Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   ��  �� Path$ Linea�  5/      $ Hidden=�6-    6A   �� $ 
IdLibroLog�  50      $ Hidden=�6-    6A   �� $ IdLibro�  51      $ Hidden=�6-    6A   �� $ FechaComprobante�  52      $ Hidden=�6-    6A   �� $ TipoComprobante�  53      $ Hidden=�6-    6A   �� $ SerieComprobante�  54      $ Hidden=�6-    6A   �� $ TipoDocumento�  55      $ Hidden=�6-    6A   �� $ CodigoDocumento�  56      $ Hidden=�6-    6A   �� $ ValorVentaOriginal�  57      $ Hidden=�6-    6A   �� $ Moneda�  58      $ Hidden=�6-    6A   �� $ 
TipoCambio�  59      $ Hidden=�6-    6A   �� $ VV�  5:      $ Hidden=�6-    6A   �� $	 IGV�  5;      $ Hidden=�6-    6A   �� $ PV�  5<      $ Hidden=�6-    6A   �� $ FechaModificada�  5=      $ Hidden=�6-    6A   �� $ TipoComprobanteModificado�  5>      $ Hidden=�6-    6A   �� $ NumeroSerieModificado�  5?      $ Hidden=�6-    6A   �� $! NumeroComprobanteModificado�  5@      $ Hidden=�6-    6A   �� $ VVModificado�  5A      $ Hidden=�6-    6A   �� $ IGVModificado�  5B      $ Hidden=�6-    6A   �� $ PVModificado�  5C      $ Hidden=�6-    6A   �� $ NumeroUnicoOperacion�  5D      $ Hidden=�6-    6A   �� $ OperacionNoGravada�  5E      $ Hidden=�6-    6A   �� $ estado�  5F      $ Hidden=�6-    6A   �� $ FechaVencimiento�  5G      $ Hidden=�6-    6A   �� $ ValorEmbarcadoExportacion�  5H      $ Hidden=�6-    6A   �� $ operaciongravada�  5I         
IsReadOnly .    Header$ 	Secuencia��6?      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6R   $ Visible=�6]    6r   �� $ Numero�  5J       . $ Comprobante��6?   $	 100 6T   $ Visible=�6`    6u   �� $ NumeroComprobante�  5K       . $ 	Documento��6?   $	 100 6R   $ Visible=�6^    6s   �� $ NumeroDocumento�  5L       . $ Razon Social��6?   $	 220 6U   $ Visible=�6a    6v   �� $ NombreRazonSocial�  5M       . $	 CUO��6?   $	 100 6L   $ Visible=�6X    6m   �� $ CodigoUnicoOperacion�  5N      $ Correlativo��6-   $	 100 6B   $ Visible=�6N    6c   �� $ NumeroCorrelativo�4  .System.Windows.Controls.DataGridTemplateColumn  5O      $ Guardar��61   $ 70 6B   $ Visible=�6M      CellTemplate 5P      �� 5Q   "   .R�5R   &   �� -   5        ��5S   *   �� 5T   .   .+�5U   2   �� $��20��68   $��20��6C   $��/Recursos/Iconos/save.png��6O   5V   /   5X   '   5Y   #   5[      5]      5^      5_      5`      5a      