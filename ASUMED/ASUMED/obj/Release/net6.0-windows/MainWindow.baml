   M S B A M L   `   `   `  ���� 
  ASUMED    ASUMED.MainWindow   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$	  Pop��$	��400��$	��320�� � WindowStyle$
 None=� � AllowsTransparency$
 True��
������  � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.����  �� CornerRadius$ 15������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF29ABE2��� $ 	#FF85DBFF��	 � Offset$	 1Q�._�� 
 � RowDefinitions
 �� $
��0.5* ��� $��3* ��� $��5* ��� $
��0.5* �.+�� -    �Name$ TitleBar��
������ $��0��$��28��$	��Top=�.+���  �� Orientation$ 
Horizontal=�$��Right=�.+��� -   $��LineImg��$��25��$��4q�����  �� 
TargetType" ��.���  �� Property � �� �� Value$ Sources\Line.png�� �� Triggers ��  �� Binding �� *IsMouseOver+ �� ElementName$ LineImg�� �� Value True.a���  � ��$ Sources\lineact.png���� -   $��CrossImg��$��25��$��4,4,15,4q����� " ��.���  � ��$ Sources\Cross.png�� ��  �� *IsMouseOver+$ CrossImg�� True.a���  � ��$ Sources\CrossAct.png��� -   $ LogoGrid��
������ $��1��.+��� -   $��Sources\SS_logo_gray.png��� $��2��
 �� �� $��9* ��� .+�� $��1��
 �� �� $��15 ��� �� �� $��1 �.+�� $��0��.+��� $��40��$	��270�����	#FFB9EAFF$ 15��$��2q�._��� -    ��Name$ 	textLogin��$	��265��
������ $��0q�$��30(�
������� �� TextAlignment$ Center=�$��Center=�� $��2��.+��� $��40��$	��270�����	#FFB9EAFF$ 15��$��2q�._�G� -    G�Name$ textPass��$	��265��
������ $��0q�$��30(�
�������$��Center=�$��Center=�� $��3��.+��� -	   $��Center=�$��Bottom=����	#FFB9EAFF$��30��$��40��$	��200��$ 15�� � Cursor$
 Hand��._��� $��Center=�$��Center=�$��Segoe Print)�$��20(�
���   �.��Увійти� $��3��.+��� $��Center=�$��Light"����	#FF57C3ED$��10(�$��ТОВ "S&S"��