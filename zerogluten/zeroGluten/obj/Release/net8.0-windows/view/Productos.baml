   M S B A M L   `   `   `  ���� E  AzeroGluten, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:zeroGluten.viewzeroGluten.view      zeroGluten.view.Productos   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:zeroGluten.view       � Title$  	Productos��$	��720��$
��1200�� � Cursor$  �� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency$
 True�� � WindowStyle$
 None=�.��� .+�(� .��� ���#D9C5B4$	��842��$	��457�� � ColumnDefinitions �� $	��170 ��� $��* �.+��� .+��� $��/images/logo-app.png��$��Center=�$��98��$��0,21,0,0q�$	��Top=�$��98���� -   $��btnProductos��$��5, 40, 5, 0q����#442129$	��130��$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"�.��� .+��� $&�� /images/menu/icono-productos.png��$��20��$��20��$��Center=�$
��Left=�$��5,0,0,0q��� $��	Productos��$��30,0,5,0q�$��Center=�
������ ���#e9e4dd�� -   $��
btnRecetas��$��
5, 5, 5, 0q����#442129$	��130��$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"�.��� .+��� $$��/images/menu/icono-recetas.png��$��20��$��20��$��Center=�$
��Left=��� $��Recetas��$��	25,0,10,0q�$��Center=�
������ ���#e9e4dd�� -    ��Name$ 	btnBuscar��$��5, 20, 5, 0q����#442129$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"�$	��130��.��� .+��� $#��/images/menu/icono-buscar.png��$��18��$��19��$��Center=�$
��Left=��� $��Buscar��$��	25,0,10,0q�$��Center=�
������ ���#e9e4dd�� -   $ btnLimpiarFiltros��$��
5, 5, 5, 0q����#442129$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"�$	��130��.��� .+��� $0��*/images/productos/ico-cancelar-filtros.png��$��18��$��19��$��Center=�$
��Left=��� $��Limpiar filtros��$��	25,0,10,0q�$��Center=�
������ ���#e9e4dd� $��1��$��10q� � RowDefinitions �� $
��Auto ��� $��* �.+�9� $��Filtros��	 9� ExpandDirection$
	 Down=����#e9e4dd$��0,10,10,358q�$��2��
 9� 
IsExpanded$

 True��$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"�.���� .+�� -    �Name$ filtrosProductos��$y�Visible=�.+��� $
��Left=�$��10,5,0,0q�$��Nombre��$	��120��$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"��� -    ��Name$ tbNombreProd��$
��Left=�$��	10,20,0,3q�$	��115��$*��$pack://application:,,,/font/#Maxwell)��� $
��Left=�$��	170,5,0,0q�$��Calorias máximas��$	��120��$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"��� -   $��cbCaloriasMax��$
��Left=�$��
170,20,0,0q�$	��Top=�$	��115��$��17���� $
��Left=�$��	325,5,0,0q�$��Proteinas minimas��$	��120��$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"��� -   $��cbProteinasMin��$
��Left=�$��
325,20,0,0q�$	��Top=�$	��115��$��17���� $
��Left=�$��	485,5,0,0q�$��Grasas maximas��$	��120��$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"��� -	   $��cbGrasasMax��$
��Left=�$��
485,20,0,0q�$	��Top=�$	��115��$��17��� -
   $ filtrosRecetas��$y�	Collapsed=�.+��� $
��Left=�$��10,5,0,0q�$��Nombre��$	��120���� -   $ tbNombreRecet��$
��Left=�$��	10,20,0,3q�$	��115��$*��$pack://application:,,,/font/#Maxwell)��� $
��Left=�$��	170,5,0,0q�$��Tiempo de preparacion��$	��120���� -   $��cbTiempoReceta��$
��Left=�$��
170,20,0,0q�$	��Top=�$	��115��$��20���� $
��Left=�$��	325,5,0,0q�$��Intolerancias��$	��120���� -   $��cbIntolerancias��$
��Left=�$��
325,20,0,0q�$	��Top=�$	��115��$��20��.@��� $��Lacteo���� $��Huevo���� $��Gluten���� $��Marisco���� $
��Soja���� $��Trigo���� $
��Left=�$��	485,5,0,0q�$��Tipo de comida��$	��120���� -   $��cbTipoComida��$
��Left=�$��
485,20,0,0q�$	��Top=�$	��115��$��20��.@��� $��Plato���� $��Postre���� $	��Pan���� $��Bebida��� $��1��.+��� -    ��Name$ lbProductos��$��	0,86,10,0q�$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"��� -   $ btnMinimizar��$��1��$��-��$��20��$��20��$
��Left=�$��	627,0,0,0q�$	��Top=�����  �� 
TargetType" ��.���  �� Property � �� �� Value
 ���� ��  � ��
 �������  � ��
 ���� ��  � ��$ 0q���  � �� ��  �� 
TargetType" ��.R���  ��Name$ border��#��z�� �� CornerRadius$
 17.5��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ���  �� 
TargetName$ border�� � ��
 �������  � ��
 �   ��� -   $��	btnCerrar��$��1��$��X��$��20��$��20��$
��Left=�$��	652,0,0,0q�$	��Top=����� " ��.���  � ��
 ���� ��  � ��
 �������  � ��
 ���� ��  � ��$ 0q���  � �� �� " ��.R��� $ border��#��z��$
 17.5��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �#f44336��  � ��
 ������� $
��Left=�$��
10,430,0,0q�$
��Wrap=�$��	Siguenos:��$	��Top=�$*��$pack://application:,,,/font/#Maxwell)�$
��Bold"�$��56��$��15(�� .+��� $+��%/images/productos/icono-instagram.png��$
��Left=�$��18��$��
81,430,0,0q�$	��Top=�$��17���� $#��/images/productos/icono-x.png��$
��Left=�$��17��$��103,430,0,0q�$	��Top=�$��17���� $(��"/images/productos/icono-tiktok.png��$
��Left=�$��16��$��125,431,0,0q�$	��Top=�$��15��