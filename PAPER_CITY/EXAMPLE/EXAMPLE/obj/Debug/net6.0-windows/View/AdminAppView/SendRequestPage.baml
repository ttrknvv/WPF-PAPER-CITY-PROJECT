   M S B A M L   `   `   `  ����D  @PaperCity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:EXAMPLE.View.AdminAppViewEXAMPLE.View.AdminAppView  5      /    )EXAMPLE.View.AdminAppView.SendRequestPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:EXAMPLE.View.AdminAppView     5        N� 
Background
  ����  N� Title$ SendRequestPage��5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ FilterCatalog��5      $��0��5         FilterStyleText#���   5      $
��Left=�5      $��10, 0, 0, 0q�5      5      �� 5   
     ForButtonWithIconRefresh#���  6   $��0, 0, 80, 0q�5      $��Right=�5      ��5      �� *RefreshReview+�� 5   
   -   5         ��Name$ ListReviews��5      
������ $��0q�5      $	��720��5      $��1��5       ��5!      �� *
ReviewPr+ � 	Resources 5"       �� 
TargetType �� Property  VerticalScrollBar �� Value��%P   '��       �� 5#      " ��6   .�5$      ��  � ��# �  61   5%      5&      ��5'      �� 5(      " ��6   .�5)      -   5        �� 5*       � ��
 ���� 63   �� 5+       � ��$
 Left=�6<   �� 5,       � ��$ Center=�6:   �� 5-       � ��$	 720��6.   �� 5.       � ��$ 0, 6, 10, 10q�6/   �� 5/       � ��$
 Auto��6/   �� 50       � �� 51      �� 52      	 �� 
TargetType"	 ��6.   .R�53   "   �� $��0q�6)   $��Center=�6=   
������ #��z��6t   ._�54   &   �� #��z��67   #��z��55   ;   #��z��56   ;   #��z��57   ;   58   #   59      5;      
 �� Triggers
 5<      P� 5=       P� Property �@J�IsMouseOver P� Value$
 True��69   . �5>      ��  � �� �	#FF1B3E656;   5?      5B      ��5D      �� 5E      .R�5F      ��  �� Orientation$ Vertical=�6!   $
��Left=�5G   !   $
��Auto��5I       ��5H       �� *ActualWidth+ �� ElementName$ CatalogBooks��5I       5K      ��5M      �� 5N      .R�5O      �  � Orientation$ 
Horizontal=�6    $	��720��5P       $��20, 0, 0, 0q�5Q       $
��Auto��5R       .+�5S      �� $��
0, 4, 0, 0q�6%   .+�5T      � .+�5U   "   �� .+�5V   &   ��   	IdMessage#���  60   ���	#FF9E788F5W   (   �� 5X   &   ���	#FF96ADC8��60   �� *	ID_REVIEW+5Y   (   5Z   #   �� 5[   "   $��60, 0, 0, 0q�6-   $	��200��5\   %   .+�5]   &   ��   	PlugLogin#���  60   ���	#FF9E788F5^   (   �� 5_   &   ���	#FF96ADC8��60   �� *LOGIN+5`   (   5b   #   �� 5c   "   .+�5d   &   ��   DateTestBuy#���  60   ���	#FF9E788F5e   (   �� 5f   &   ���	#FF96ADC8��60   �� *DATE+ �� StringFormat$ {0:dd.MM.yyyy}��5g   (   5h   #   5i      �� 5j        Message#���  6(   ���	#FF9E788F$��0, 10, 0, 0q�5l   (   �� 5m      $��0, 10, 0, 10q�6%    �� CornerRadius$ 6��5n   %   $��0q�5o   %   ���	#FFB8CEE7._�5q   "   ��   MessageReview#���  5r   (   ��5q   ,   �� *REVIEW_TEXT+5r   (   5s      5t      5v      5w      5y      5z      5{      