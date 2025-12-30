EXTERNAL VerifyQuest()

-> start

=== start ===
A long time ago—well, maybe not *that* long ago, but long enough for me to still be upset about it—a couple of orcs stole my candy.

Not just *any* candy!  
It was a rare, hand-crafted, triple-caramel, frost-dusted, chocolate-infused, rainbow-swirled candy orb of joy.  
A masterpiece.

I’ve been searching high and low, under rocks, inside hollow trees, and even in my neighbor’s suspiciously large sock drawer. But alas… nothing.

Tell me, traveler… by any slim, miraculous chance…  
Have you come across my precious candy?

+ [Yes]
  ~ VerifyQuest()
  -> success
+ [No]
  -> failure


-> DONE


=== success ===
IS THAT—  
It is! It IS! MY CANDY!

Oh, radiant hero of taste buds and justice!  
You have no idea how much this means to me. I thought the orcs would have devoured it the moment they got their grubby hands on it!

Please, accept this gift:  
A small charm said to bring good luck, mild fortune, and an increased chance of finding stray snacks on the ground.

Treasure it wisely… or eat it—I mean, NO, don’t eat it. It’s not edible. Probably.

-> postCompletion


=== failure ===
The orcs… still have it?

Blasted creatures!  
Always running, always hoarding shiny things, always leaving muddy footprints everywhere they go.  
Did you know one of them once stole my left boot?  
JUST ONE.  
What kind of monster steals *one* boot?

Well… thank you for at least trying.  
If you ever track them down again, or reclaim my beloved candy orb, I will sing your praises across this entire region!  
Or at least hum your praises quietly so I don’t attract wolves.

-> postCompletion


=== postCompletion ===
Thank you for listening to my tale of confectionery tragedy.

Should your travels cross paths with the orcs again—or should fortune deliver candy into your hands—my door is always open…  
mostly because the hinge broke and I can’t afford to fix it.

Safe travels, sweet hero.

-> END
