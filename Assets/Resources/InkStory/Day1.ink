/*
以下為我目前對應編譯器本身的Bug和我自己迴避Bug的方式所用的格式
當要觸發選擇事件時，你可以用LIST來記錄之前選項
寫法為~ listname = listitem
當要觸發追逐遊戲時，在句子(不能為按鈕)最後打上&CHECKMINIGAME
，而如果下句是要進入下一天的句子，則要多打一行，不然會有Bug
每個觸發追逐戰的判斷盡量有順序可以讓我可以看，我比較好寫程式，你可以在最前面宣告LIST的地方寫他們出現的順序，我目前打的為範例，如果有重複使用則往後繼續打數字就好(像我額外寫的4和5)
如果你除了邪教徒路線外還有其他想增加的數值判斷，先暫時打&AddXXXXNum
我之後比較方便增加判斷的數字

*/



LIST gift = flower, book, condom //1
LIST shirtcolor = yellow, blue //2、4
LIST nightmare = yes, no //3、5


//玩家立繪開心
昨天暗戀已久的社團學姐客舒如竟然和我表白了，今天是我們第一次約會。
->clothing
===clothing===
//玩家立繪緊張
-我好緊張，不知道需要穿什麼衣服...
*[黃色T恤]
~shirtcolor = yellow
*[藍色T恤]
~shirtcolor = blue
-->object

===object===
-除此之外，不知道要帶一點什麼...
*[一束花]
    {~gift = flower}
*[保險套]
    {~gift = condom}
*[克蘇魯的呼喚小說]
    {~gift = book}
-->transpotation

===transpotation===
-啊啊快要遲到啦！我該怎麼去赴約呢...
*[坐捷運]
->MRT
*[跑過去]
->Delay
*[騎我超帥的爆改勁戰]
->Delay
->DONE

===MRT===
還好沒等很久，剛好在時間內趕到。
->Restaurant

===Delay===
//客舒如立繪怒
客舒如:「你遲到了！我最討厭遲到的人」
我拿出準備好的禮物&CHECKMINIGAME
{ gift == book:
        ->Restaurant
-else:
        ->Revive
}
//->Restaurant
//克蘇魯的呼喚小說以外，都會惹怒她，進入跑酷模式，跑酷結束進入Revive
===Mortocycle===
//玩家立繪怒
我:「淦！塞車...」
->Delay

===Gift===
//客舒如立繪驚訝
客舒如:「你怎麼知道這是我最喜歡的小說！」
//玩家立繪開心
我:「因為...我愛你啊！」
//客舒如立繪羞澀
客舒如：「哼！原諒你一次。」
->Restaurant

===Revive===
//玩家立繪疑惑
我:「剛剛發生了什麼事？為什麼我都不記得了？」
//客舒如立繪開心
客舒如:「什麼事也沒有唷~」
我還是滿臉問號。
->Restaurant
===Restaurant===
吃飽飯後...
//客舒如立繪開心
客舒如:「今天這家餐廳真好吃耶！」
//玩家立繪開心
我:「學姊喜歡真是太好了，這裡還有很好吃的冰淇淋喔！」
//兩人立繪都變暗
服務生:「這裡是您點的冰淇淋聖代，餐點都到齊了喔！」
//客舒如立繪開心
客舒如:「幫我和它拍照！」
學姊說完，卻把餐具和聖代依照某個規律整齊排好，她自己用臉貼近聖代。
我不知道這個舉動有什麼意義，但看著她可愛又滿意的笑容，只覺得有女友如此夫復何求。
冰淇淋不小心沾在了學姊完美的臉頰上，我下意識地伸出手指幫她抹去。
客舒如:「啊！謝謝。」
她竟然握住我的手指，並將其含入口中，用一種難以言喻的方式吸吮我的指尖。
這畫面本應很撩人，但我卻隱約覺得有些不對勁。
整整過了五秒，那觸感冰冷又帶有點黏稠，我的表情逐漸母湯，學姊似乎也注意到了。
客舒如:「抱歉，我不常和人類交往，不太知道你們的規矩。」
//玩家立繪疑惑
我:「人類？」
客舒如:「沒事，口誤而已啦！因為我住在鄉下，對城市的一些是比較不了解。」
我:「沒事，沒事，我只是有點嚇到而已啦！只要學姊喜歡，就算把我吃了也沒關係。」
一瞬間學姊露出滿足的微笑，真是可愛。
這時下腹部突然一陣劇痛。
//玩家立繪緊張
我:「我去個廁所...」
話音未落，我就衝向廁所。
這是一次很有值得深思的體驗，我感覺坐上馬桶就將體內所有器官排了出來，
有些頭暈目眩，不知道時間過了多久。
//玩家立繪哀怨
我:「唉，怎麼偏偏在和學姊約會時烙賽。」
我走出廁所，餐廳的情景卻讓我驚呆了。
原本高朋滿座的地方，卻變得空無一人，只剩下收銀檯那可憐的服務生。
他兩眼空洞，不斷用臉敲打著收銀機的抽屜。
//玩家立繪緊張
我:「醒醒啊！請問你有沒有看到剛才和我一起來的那個女生？」
服務生:「那個女生...？那個...」
他的眼睛裡彷彿見到某種很恐怖的東西而收縮，接著就沒了意識。
我心急如焚地衝出餐廳，卻看到學姊好整以暇地站在門外。
見到我卻皺起了眉頭，似乎有點不悅。
//客舒如立繪皺眉
客舒如:「你跑去哪了？怎麼那麼久？」
*[剛剛裡面發生了什麼事？]
->WhatHappened
*[我只是有點吃壞肚子]
->outside

===WhatHappened===
我卻突然怎麼也開不了口，反而言不由衷地說到。
->outside
===outside===
我:「我只是有點吃壞肚子。」
//客舒如立繪擔心
學姊滿臉擔心地看著我，並用手摸了摸我的額頭。
客舒如:「你要好好照顧身體啊！」
//玩家立繪舒爽
感受到學姊的關心，我瞬間忘掉了一切，真想要時間暫停在這個瞬間。
客舒如:「時間也不早了，我們回去吧！」
//客舒如立繪害羞
學姊這時突然有些忸怩
客舒如:「我自己在台北租屋，有時候晚上會怕，你...要不要來陪我？」
我:「既然學姊都這麼說了，那有什麼問題。」
->Home
===Home===
跟著她一起到了家裡，學姊突然給我一個擁抱。
她嘴唇貼在我耳朵旁。
客舒如:「你應該是第一次吧，喜歡怎麼樣的方式？」
*[一般]
->Normal
*[多人]
->3P

===3P===
//玩家立繪傻笑
不敢相信學姊竟然接受了我的提議...&ADDEVILNUM
/*直接到第二天，起床時玩家會忘記夜裡發生了什麼。
這是邪教路線的入口，這些多人混戰的參與者都成為邪神復甦的犧牲品，看這邊能否設一個變數來記錄選擇多人的次數*/
->END

===Normal===
//玩家立繪傻笑
~nightmare = no
我們享受了一次完美的性愛，然後心滿意足的睡了。
{shirtcolor == yellow:->Nightmare}
{gift != condom:->Nightmare}
->END


===Nightmare===
~nightmare = yes
我做了一個奇怪的夢，學姊彷彿成為怪物，並且追在我後頭。
我只能不停地跑著... &CHECKMINIGAME
....
//進入橫向跑酷，醒在NightmareAwake
->END




