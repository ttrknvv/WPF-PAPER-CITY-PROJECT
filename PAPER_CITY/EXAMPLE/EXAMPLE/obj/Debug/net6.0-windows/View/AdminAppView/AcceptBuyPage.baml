   M S B A M L   `   `   `  ����D  @PaperCity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EXAMPLE.View.AdminAppViewEXAMPLE.View.AdminAppView  5      -    'EXAMPLE.View.AdminAppView.AcceptBuyPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:EXAMPLE.View.AdminAppView     5        N� 
Background
  ����  N� Title$ AcceptBuyPage��5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   ��    ForButtonWithIconRefresh#���   6   $��Center=�5      ��5      �� *RefreshPayment+�� 5   
   -   5         ��Name$ 
ListPaying��5      
������ $��0q�5      $	��720��5      $��1��5      ��5      �� *
Payments+ � 	Resources 5       �� 
TargetType �� Property  VerticalScrollBar �� Value��%P   '��       �� 5      " ��6   .�5      ��  � ��# �  61   5      5      ��5       �� 5!      " ��6   .�5"      -   5        �� 5#       � ��
 ���� 63   �� 5$       � ��$
 Left=�6<   �� 5%       � ��$ Center=�6:   �� 5&       � ��$	 720��6.   �� 5'       � ��$ 0, 6, 10, 10q�6/   �� 5(       � ��$ 90��6/   �� 5)       � �� 5*      �� 5+       �� 
TargetType" ��6.   .R�5,   "   �� $��0q�6)   $��Center=�6=   
������ #��z��6t   ._�5-   &   �� #��z��67   #��z��5.   ;   #��z��5/   ;   #��z��50   ;   51   #   52      54      	 �� Triggers	 55      P� 56      
 P� Property
 �@J�IsMouseOver P� Value$
 True��69   . �57      ��  � �� �	#FF1B3E656;   58      5;      ��5=      �� 5>      .R�5?      ��  �� Orientation$ Vertical=�6!   $
��Left=�5@   !   $
��Auto��5B       ��5A       �� *ActualWidth+ �� ElementName$ CatalogBooks��5B       5D      ��5F      �� 5G      .R�5H      �  � Orientation$ 
Horizontal=�6    $	��720��5I       $��20, 0, 0, 0q�5J       .+�5K      �� $��10, 0, 0, 0q�6%   $��70��5L   %   .+�5M      �� $��Id операции��6(   ���	#FF9E788F5N   (   �� 5O      ���	#FF96ADC8��6(   �� *ID_PAY+5P   (   5Q      �� 5R      $��20, 0, 0, 0q�6%   $	��130��5S   %   .+�5T      ��  
 IdUser#���  6(   ���	#FF9E788F5U   (   �� 5V      ���	#FF96ADC8��6(   �� *	ID_USER+5W   (   �� 5X       
 IdBook#���  6(   ���	#FF9E788F5Y   (   �� 5Z      ���	#FF96ADC8��6(   �� *	ID_BOOK+5[   (   5\      �� 5]      $��20, 0, 0, 0q�6%   .+�5^      ��   
NumberCard#���  6(   ���	#FF9E788F5_   (   �� 5`      ���	#FF96ADC8��6(   �� *NUMBER_CARD+5a   (   �� 5b        DateTestBuy#���  6(   ���	#FF9E788F5c   (   �� 5d      ���	#FF96ADC8��6(   �� *DATE+5e   (   5f      �� 5g      $��40, 0, 0, 0q�6%   .+�5h      ��   NameOwnerCard#���  6(   ���	#FF9E788F5i   (   �� 5j      ���	#FF96ADC8��6(   �� *
NAME_OWNER+5k   (   5l      5n      5o      5q      5r      5s      