   M S B A M L   `   `   `  ����   Carestream.AdmTramasPLE0    *Carestream.AdmTramasPLE.Procesos.UpdateCUO   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Actualizar CUO��$��414.925��$	��860��.��� .+��� .+��� $��Búsqueda de CUO��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��830��.���  � RowDefinitions �� $
��auto ��� $
��auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�	� $��0��$��0�� 	� 	GroupName$
 Tipo��$��Ventas�� d� 	IsChecked$
 TrueY�$��3,3,8,3q�	� $��0��$��1��$
 Tipo��$��Compras��$ FalseY�$��3,3,8,3q�$y�Hidden=��� -   $��LblBusqueda��$��1��$��0��$��5,2,5,5q�$��5,2,5,5q�����  �� Orientation$ 
Horizontal=�.+��� $��20��$��20��$!��/Recursos/Iconos/search.png���� $��Ingresar CUO: ��$��3,3,8,3q��� -   $��TxtCUO��$��1��$��1��$��80��$��23�����	#FFF6FB90�� -   $��LblAnio��$��1��$��2��$��Año:��$��5,2,5,5q�$��5,2,5,5q��� -   $��TxtAnio��$
��Left=�$��1��$��3��$��80��$��23��$��5,5,5,2q��� -   $��LblMes��$��1��$��4��$
��Mes:��$��5,2,5,5q�$��5,2,5,5q��� -   $��CmbMes��$
��Left=�$��1��$��5��$��23��$	��5,2q�$	��150�� �� DisplayMemberPath$ Nombre�� �� SelectedValuePath$
 sCod������ �� -   $��lblCiclo��$��1��$��6��$��Ciclo:��$��5,2,5,5q�$��5,2,5,5q�	� -	   $��
rbApertura��$��1��$��7��$ Ciclo��$��Apertura��$
 TrueY�$��3,3,8,3q�	� -
   $��	rbMensual��$��1��$��8��$ Ciclo��$��Mensual��$ falseY�$��3,3,8,3q�	� -   $��rbCierre��$��1��$��9��$ Ciclo��$��Cierre��$ falseY�$��3,3,8,3q��� $��	Resultado��$
��left=�$��	10,10,0,0q�$	��top=�$
��auto��$	��830��.��&   System.Windows.Controls.DataGrid  -   $��GridCuoVentas��$��5,5,5,5q�   CanUserAddRows .  	   CanUserResizeColumns	 .  
   SelectionMode$
 Single=�"   VerticalScrollBarVisibility$ Visible=�$	��240��   AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ Linea�  $ Hidden=� �� $ 
IdLibroLog�  $ Hidden=� �� $ IdLibro�  $ Hidden=� �� $ FechaComprobante�  $ Hidden=� �� $ TipoComprobante�  $ Hidden=� �� $ SerieComprobante�  $ Hidden=� �� $ TipoDocumento�  $ Hidden=� �� $ CodigoDocumento�  $ Hidden=� �� $ ValorVentaOriginal�  $ Hidden=� �� $ Moneda�  $ Hidden=� �� $ 
TipoCambio�  $ Hidden=� �� $ VV�  $ Hidden=� �� $	 IGV�  $ Hidden=� �� $ PV�  $ Hidden=� �� $ FechaModificada�  $ Hidden=� �� $ TipoComprobanteModificado�  $ Hidden=� �� $ NumeroSerieModificado�  $ Hidden=� �� $! NumeroComprobanteModificado�  $ Hidden=� �� $ VVModificado�  $ Hidden=� �� $ IGVModificado�  $ Hidden=� �� $ PVModificado�  $ Hidden=� �� $ NumeroUnicoOperacion�  $ Hidden=� �� $ OperacionNoGravada�  $ Hidden=� �� $ estado�  $ Hidden=� �� $ FechaVencimiento�  $ Hidden=� �� $ ValorEmbarcadoExportacion�  $ Hidden=� �� $ operaciongravada�     
IsReadOnly .    Header$ 	Secuencia��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 $ Visible=� �� $ Numero�   . $ Comprobante��$	 100 $ Visible=� �� $ NumeroComprobante�   . $ 	Documento��$	 100 $ Visible=� �� $ NumeroDocumento�   . $ Razon Social��$	 220 $ Visible=� �� $ NombreRazonSocial�   . $	 CUO��$	 100 $ Visible=� �� $ CodigoUnicoOperacion�  $ Correlativo��$	 100 $ Visible=� �� $ NumeroCorrelativo�4  .System.Windows.Controls.DataGridTemplateColumn  $ Guardar��$ 70 $ Visible=�   CellTemplate �� .R��� -   ���� .+��� $��20��$��20��$��/Recursos/Iconos/save.png��