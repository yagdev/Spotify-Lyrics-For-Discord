   M S B A M L   `   `   `  ����N  JDiscordRPCAttempt2, Version=24.3.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DiscordRPCAttempt2DiscordRPCAttempt2  5   	   #    DiscordRPCAttempt2.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:DiscordRPCAttempt2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ Token��5
      $��Label��6!   $��10,10,261,380q�6.   �� 5   
   -   5        $
��Auth��5      $
��Left=�6    $��	10,0,0,10q�6;   $��Bottom=�6N   $	��167��6i   $��53��6u   6�   �� 5   
   -   5        $ Status��5      $��Label��6"   $��10,54,261,339q�6/   �� 5   
   -   5        $��	Get Album��5      $��Right=�6%   $��
0,0,10,313q�6A   $��Bottom=�6U   $	��167��6p   $��53��6|   6�   �� 5   
   -   5         ��Name$ 
albumcover��5      $
��Left=�6$   $	��100��6?   $��	10,0,0,67q�6L   $��Bottom=�6_   $	��100��6z   �� 5   
   -   5        $��Get Song��5      $��Right=�6$   $��
0,0,10,371q�6@   $��Bottom=�6T   $	��167��6o   $��53��6{   6�   �� 5   
   -   5        $��Get Timestamp��5      $��Right=�6)   $��
0,0,10,255q�6E   $��Bottom=�6Y   $	��167��6t   $��53��6�   6�   �� 5   
   -   5        $ DebugShit2_Copy��5      $��Label��6+   $��	0,0,10,10q�68   $	��240��6K   $��Bottom=�6X   $��Right=�6s   $	��246��6�   �� 5   
   -	   5        $ 	SongTitle��5      $��Label��6%   $��10,95,261,298q�62   �� 5   
   -
   5        $ 	Timestamp��5      $��Label��6%   $��10,136,261,257q�62   �� 5   
   -   5        $ Timestamp_Local��5      $��Label��6+   $��10,177,261,216q�68   �� 5   
   -   5        $ 
LyricsShit��5      $��Label��6&   $��10,218,261,175q�63   �� 5   
   -   5        $ 	AlbumLink��5      $��Label��6%   $��10,259,261,134q�62   �� 5   
   -   5        $ SongID��5      $��Label��6"   $��10,300,261,93q�6/   �� 5   
   -   5        $ 	LyricShit��5      $��Label��6%   $��10,341,261,52q�62   �� 5   
   -   5        $ NewTokiShit��5      $��Label��6'   $��182,382,261,11q�64   �� 5   
   $��Debug��6   $��Right=�6    $��
0,67,155,0q�6<   $	��Top=�6P    J� RenderTransformOrigin$ 0.5,0.5&�6h   $��81��6�   $��22(�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 90Q�6&   T� 5       5!      5#      �� 5$   
   $)��#You are running on a release build!��6   $��Right=�6>   $��
0,80,143,0q�6Z   $	��Top=�6n   $ 0.5,0.5&�6�   $	��183��6�   $��11(�6�   $��Center=�6�   $��Center=�6�   z�5%      V� 5&      .~�5'      �� �� 5(      �� 5)      $ 90Q�6&   T� 5*      5+      5-      5/      50      