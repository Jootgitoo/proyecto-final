   M S B A M L   `   `   `  ����E  AzeroGluten, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:zeroGluten
zeroGluten  5   	       zeroGluten.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:zeroGluten     5   	     � Title$  
MainWindow��5   	   $	��720��6   $
��1200��6)    � Cursor$  ��66    � 
ResizeMode$ NoResize=�5	       � WindowStartupLocation$ CenterScreen=�5
      
������  � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	   .��5      (� .��5   
   � $	��799��6   $	��430��6   ���#D9C5B4.+�5      �� $��/images/logo-app.png��6   $
��Left=�62   $	��436��6M   $��Center=�6Z   $	��436��6u   ${�False��6�   �� 5      -   5        $��txtBlockNombreUsuario��5      $
��Left=�63   $��466,119,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $#��Escriba el nombre del usuario��6w   $	��Top=�6�   $	��309��6�   
������ 
������ $*��$pack://application:,,,/font/#Maxwell)�6�   6%  �� 5      
���   �$��1��6%   $	��309��60   $	��Top=�6<   $��466,135,0,0q�6T   $
��Left=�6i   �� 5      -   5        $��txtBlockPassword��5      $
��Left=�6.   $��466,219,0,0q�6I   $
 Wrap=�6^   $��Escriba su contraseña��6r   $	��Top=�6�   $	��309��6�   
������ 
������ $*��$pack://application:,,,/font/#Maxwell)�6�   6  �� 5      
���   �$��1��6%   $	��309��60   $	��Top=�6<   $��466,235,0,0q�6T   $
��Left=�6i   �� 5      -   5        $��btnIniciarSesion��5      $��Iniciar Sesion��6-   $
��Left=�6F   $��466,299,0,0q�6a   $	��Top=�6v   $��29��6�   $	��110��6�   ���#400101���#DEDEDE$*��$pack://application:,,,/font/#Maxwell)�6�   $
��Bold"�6  6  �� 5      -   5        $��btnRegistrarse��5      $��Resgistrarse��6+   $
��Left=�6B   $��665,299,0,0q�6]   $	��Top=�6r   $��29��6�   $	��110��6�   ���#400101���#DEDEDE$*��$pack://application:,,,/font/#Maxwell)�6�   $
��Bold"�6�   6  �� 5"      -   5         ��Name$ btnMinimizar��5"      $��20��6/   $��20��6:   
������ 
������ 
�������$��-��6�   $
��Left=�6�   $��	754,0,0,0q�6�   $	��Top=�6�   ��5#      �� 5$       �� 
TargetType" ��6   .�5&      �� 	 �� Property	 � ��
 �� Value

 ���� 67   �� 5'      	 � ��

 �����67   �� 5(      	 � ��

 ���� 68   �� 5)      	 � ��$
 0q�6<   �� 5*      	 � ��
 5+      �� 5,   "    �� 
TargetType" ��62   .R�5-   &   ��  ��Name$ border��6-   #��z��6=    �� CornerRadius$
 17.5��6h   ._�5.   *   �� $��Center=�6;   $��Center=�6X   5/   '    �� Triggers 50   &   P� 52   *    P� Property �@J�IsMouseOver P� Value$
 True��6I   . �53   .   ��  �� 
TargetName$ border��65   	 � ��

 �����6_   �� 54   .   	 � ��

 �   �6K   55   +   57   #   59      5:      5<      �� 5>      -   5        $��	btnCerrar��5>      $��20��6&   $��20��61   $��X��6=   $
��Left=�6I   $��	779,0,0,0q�6d   $	��Top=�6w   ��5?      �� 5A      " ��6   .�5B      �� 	 � ��

 ���� 67   �� 5C      	 � ��

 �����67   �� 5D      	 � ��

 ���� 68   �� 5E      	 � ��$
 0q�6<   �� 5F      	 � ��
 5G      �� 5H   "   " ��62   .R�5I   &   �� $ border��6-   #��z��6=   $
 17.5��6g   ._�5J   *   �� $��Center=�6;   $��Center=�6X   5K   '    5L   &   P� 5N   *    �@J�IsMouseOver$
 True��6I   . �5O   .   �� $ border��65   	 � ��
 �#f443366_   �� 5P   .   	 � ��

 �����6K   5Q   +   5S   #   5U      5V      5X      5Z      5[      5\      