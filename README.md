# VR_DOOM

🎮 基于 Unity 的 VR 射击游戏原型，灵感来源于经典 DOOM 风格  
🎮 Unity 기반의 VR 슈팅 게임 프로토타입, 고전 DOOM 스타일에서 영감

---

##  项目介绍 / 프로젝트 소개

DOOM 是一款经典的第一人称射击游戏，以其快节奏的战斗、复杂多变的迷宫关卡设计以及充满金属风格的美术表现而闻名。
它不仅定义了早期 FPS 游戏的标准，也成为后来众多射击游戏的灵感来源。

本项目是对 DOOM 游戏的 VR 重制原型开发。
在保留原作视觉风格和战斗节奏的同时，我们引入了基于 Unity 的 XR 技术，增强了玩家的沉浸感与交互性。
玩家将能够以第一人称视角亲身体验 DOOM 世界，使用手柄抓取武器、瞄准射击，并探索经过重新构建的 VR 场景结构。
该原型项目将作为未来完整 VR DOOM 游戏开发的基础探索

OOM은 빠른 전투 리듬, 복잡한 미로형 레벨 구성, 그리고 금속풍 아트 스타일로 잘 알려진 고전 1인칭 슈팅 게임입니다.
초기 FPS 게임의 기준을 정립했으며, 수많은 후속작들에 영향을 끼친 전설적인 타이틀입니다.
본 프로젝트는 DOOM 게임을 VR 환경에서 재현한 프로토타입입니다.
원작의 시각적 스타일과 박진감 넘치는 전투 리듬을 유지하면서, Unity 기반의 XR 기술을 통해 몰입도 높은 VR 경험을 구현하였습니다.
플레이어는 VR 헤드셋과 컨트롤러를 이용해 무기를 직접 잡고, 조준하고, 사격하며 재구성된 DOOM 세계를 탐험할 수 있습니다.
이 프로토타입은 향후 완성형 VR DOOM 게임 개발을 위한 기초 연구로 사용될 예정입니다.

---

##  技术栈 / 기술 스택

- Unity 6  
- XR Interaction Toolkit  
- OpenXR + Oculus Quest 2  
- ProBuilder（用于地图编辑） / ProBuilder (맵 편집용)  
- GitHub（版本控制） / GitHub (버전 관리)

---

##  项目结构 / 프로젝트 구조
Assets/             
-  游戏资源、预制体、脚本  
-  게임 에셋, 프리팹, 스크립트

Scenes/             
-  场景文件，如主房间、通道等  
-  Unity 씬 파일들 (Main Room, Tunnel 등)

Scripts/            
-  交互控制、枪械逻辑、AI 脚本  
-  VR 인터랙션, 총기 로직, AI 스크립트

Materials/          
-  材质与贴图（复古风）  
-  메탈 재질 및 DOOM 스타일 텍스처

ProjectSettings/    
-  Unity 项目设置  
-  Unity 프로젝트 설정

.gitignore          
-  忽略缓存与编译临时文件  
-  캐시 및 임시 빌드 파일 무시

---
### 📦 素材来源 / 에셋 출처

- **Sketchfab**  
  🔗 [https://sketchfab.com](https://sketchfab.com)  
  查找并下载免费和付费 3D 模型（支持 Unity）  
  무료 및 유료 3D 모델 검색 및 다운로드 (Unity 지원)
  
- **Ammo Box**
  - Source: Unity Asset Store
  - Name: Ammo Box
  - Author: Beatheart Creative Studio
  - Link: https://assetstore.unity.com/packages/3d/props/weapons/ammo-box-7701
  - Usage: Used as Ammo Pickup in this project

---
