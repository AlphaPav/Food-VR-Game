# Food-VR-Game
##人物操作：

- 人：上下左右键对应视野的左右上下移动（改成vr版本是头盔自由旋转视野）

- 左手：AWSDZX对应手的六个自由度的旋转（改成vr版本时候手是自由移动，不需要手臂的长度限制）
    - 左手打到地面会产生高亮球，然后按鼠标右键，人就慢慢移动过去（查了资料第一人称VR游戏一般都是这种移动方式）对应脚本在LeftHandCtl
- 右手：JKILNM
    - 右手碰到物体，ui上会显示touch obj的信息；碰到的时候按鼠标左键可以抓住物体，ui上会显示grab obj的信息；
    - 抓取方式：按着鼠标左键的同时按JKILNM，松开鼠标左键放下物体，对应脚本在RightHandCtl

##物体：

- 场景中可抓取的物体都有rigidbody()、box collider，靠unity的物理系统做抓取效果
- 用于判断状态切换时的物体要挂上updateState脚本；总的状态控制在StateControl脚本
- 物体被抓取时产生黄色轮廓高亮，在ObjShowRim脚本



## 人物构造：

- Hero #总体
  - hero_controller #空的gameobject，主要为了控制身体一起移动
  - body
    - MainCamera #之后换成vr头盔的camera
    - Head #头 vr版本中会删除
    - Right #控制右手旋转
      - RightLeg #vr版本中会删除手臂
      - RightHand #RightHandCtl 控制交互
    - Left #控制左手旋转
      - LeftLeg #vr版本中会删除手臂
      - LeftHand #LeftHandCtl 控制交互
