# 프로젝트명: 도넛 키우기! (개발자: 이상헌)

#### [다운로드 링크(APK)](https://drive.google.com/file/d/1p0QNMx1AYgdJdxcTFNAPmUuWjvDCMLL8/view?usp=sharing)


# [목차]


## [1.컨셉](#컨셉)
## [2.관련이미지 & 동영상](#관련-이미지--동영상)
## [3.구성요소](#구성-요소)
## [4.게임시스템디자인](#게임시스템디자인)
## [5.개발 요구사항 & 흐름도](#개발-요구사항--흐름도)
## [6.개발작업 일정](#개발작업-일정)
## [7.스크립트 코드](#스크립트-코드)


# [컨셉]

## Project

### 1. Name
- 영문명 : Grow_Donut
- 한글명 : 도넛 키우기!

### 2. Genre : Puzzle Game

### 3. No. of Players : 1

### 4. Main Target : 30~
- 30대 이상
- Google에서 조사한 연령별 장르 선호도에서
20대부터 퍼즐선호도가 올라가면 30대부터 선호도 1위가 된다는 것을 확인가능

## Game Personality
- 게임의 기본적인 진행 방식은 드래그&드롭이다.
- 제한시간이 없는 게임이다.
- 같은 도넛이 만나면 합쳐진다.
- 도넛이 합쳐지는 과정에서 점수를 얻는다.
- 플레이 방식이 매우 간단하여 즐기기 편하다.

## Rule Summary
- 플레이어는 같은 도넛을 합치면서 최대한 많은 점수를 얻는 것이 목표이다.
- 자신의 과거 기록에 도전하는 게임이다.
- 역대 점수는 3등까지 기록된다.

## User Interface
- 모바일에서 작동하는 게임으로 게임의 우측 상단에 옵션 버튼이 존재하며 이를 통해 음량 조절, 중단 및 앱 종료 등이 가능하다.
- 기본적인 조작은 손가락으로 드래그하여 도넛의 위치를 조절하고 드랍시 도넛이 아래로 떨어진다.
- 타이틀씬에는 기록확인 버튼과 플레이 버튼이 존재한다.
- 플레이씬 좌측 상단아이콘을 클릭시 도넛의 단계별 모양을 알 수 있다.
- 플레이씬 중앙 상단에 현재 스코어가 표기된다.

## Graphic

### Graphic Concept
- 다양한 도넛에 어울리는 화려한 색감
- 배경에 도넛 실루엣을 추가하여 배경이 심심하지 않게 하였다.

### Theme
- 도넛 가게
- motive : 던킨 도넛(회사)
- 대표적인 도넛 회사
- 주황과 핑크의 이미지 컬러를 활용

### Character
- 총 11가지의 도넛
- 1단계는 먼치킨 도넛으로 구멍이 안 뚫려있기에 기본 도넛으로 적합하다.
- 고단계의 도넛으로 갈수록 점점 화려해진다.

### Puzzle
- 똑같은 도넛끼리 합쳐진다.
- 합쳐질 경우 다음단계의 도넛 1개로 탄생한다.
- 마지막 단계가 합쳐질 경우 소멸한다.

## Sound

### Sound Concept

#### BGM : 기본 배경음
- 도넛의 색상이나 간식으로서 상징으로 봤을때 가벼운 분위기의 노래가 적절하다.
- 하나의 브금을 사용하기에 씬전환에도 끊기지 않아야 한다.
- 루프를 사용하여 반복 재생하되 게임오버시 일시적으로 노래를 정지한다.

## 메인컨셉 : 머지

- 게임의 진행방식의 핵심은 도넛이 합쳐지는 것이다(머지).

### 서브 컨셉 1 : 도넛

- 합쳐지는 물체가 시각적인 매력이 있어야 재미가 있다.

### 서브 컨셉 2 : 기록

- 자신의 과거 기록을 갱신하는 것이 하나의 목표로 설정할 수 있다.

### 서브 컨셉 3 : 달성

- 기록보다는 11단계의 도넛을 보고자하는 것도 목표가 될 수 있다.


<br><br>

# [관련 이미지 & 동영상]


- 동영상  


![image](https://github.com/j0462/Growdonut/assets/70842040/ef0fb63a-5d24-4acc-b98a-d977e28b4ba0)


https://www.youtube.com/watch?v=8cGalu9FY7o&t=529s
  

<br><br>


# [대표 이미지]

![image](https://github.com/j0462/Growdonut/assets/70842040/7c798e6e-7a39-46b3-908e-77c414c6b77a)


<br><br>

# [컨셉 & 대표이미지 기반 작품묘사]

> ### 대표이미지 기반 : 도넛을 합쳐나가는 머지퍼즐게임

> ### 컨셉 기반: 도넛을 합치며 다음 단계의 도넛을 보며 기록을 갱신하는 게임

<br><br>

# [구성 요소]

<br>

## 1. 메커니즘

[도전 요소]

1) n단계 도넛에 도달한다.

2) 일정 점수에 도달한다.

3) 과거 기록을 갱신한다.

4) 역대 기록 3등안에 들어간다.

[재미 요소]

1) 도넛이 합쳐지면서 플레이어가 예상치 못한 일이 일어난다.

2) 죽기직전 운이 좋게 도넛이 연쇄적으로 합쳐지며 기사회생한다.

3) 주변 지인들과 누가 더 점수가 높은지 경쟁한다.
<br>

## 2. 이야기

[만들게 된 배경]  


2023년 구글에서 시행한 플레이스토어 시장 점유율 결과

점유율 순위는 MMO, RPG, 턴제, 퍼즐, 액션, 기타 순이였다.

MMO는 대량의 기술과 자본이 필요하기에 대기업에서 독점하는 분야이고

RPG는 최근 전략 또는 방치형이 유행하며 기업들의 투자 경쟁이 심화된 분야이다.

비교적 경쟁이 적으면서 소비층이 확실한 장르는 턴제, 퍼즐, 액션이다.

1인개발을 하면서 그림, 애니메이션을 단기간에 하는 것은 어렵기에

퍼즐 장르를 제작하기로 하였다.

[카메라 관점]  

2d 게임으로 도넛이 떨어지는 등 

진행 상황을 한눈에 잘 보이도록 정면 뷰를 사용하였다.

<br>

## 3. 미적요소

[디자인][컬러]  


도넛은 총 11개로 제작하고

비교적 화려한 색상을 넣어 제작한다.

유저들에게 구별이 잘 되도록 고단계 도넛은

과장된 모습으로 그린다.




[폰트]

폰트는 도넛처럼 둥글둥글한 것이 어울릴 것이라 판단

여기어때 잘난체 Font를 사용한다.

작품제작에는 TTF보다 OTF가 더욱 정밀하여 OTF를 사용한다.

![image](https://github.com/j0462/Growdonut/assets/70842040/1830081d-7b4d-4acc-a94e-df5760c2ae3d)





[음향]  


밝고 아기자기한 bgm을 채용하고 

UI작용 버튼음은 눌렀다는 인식을 확실하게 하기위해 간결한 음을 사용한다.

메뉴에서 옵션으로 음량 조절 기능을 만들어 음량을 조절 할 수 있도록 한다.
<br>


## 4. 기술

Unity를 기반으로 모바일 플랫폼으로 개발한다.

머지 퍼즐의 로직을 제작하여 추가하고

레지스트리 저장 방식을 사용하여 기록을 저장한다.


# [게임시스템디자인]

## a. 게임 오브젝트

|번호|명칭|이미지|
|----|----|-----|
|1|도넛|https://github.com/j0462/Growdonut/blob/main/image/donut.png|


## b. 파라미터(속성)
------------------------------------------------------------------------------------------------------------------------
1) 도넛

|속성|영문명칭|설명|비고|
|-------|-----|-----|----|
|레벨|Level|도넛의 단계로 모양 및 점수가 다름|최대 수치 = 11|
|이펙트|Particle|도넛들이 합쳐지거나 사라질때 나타나는 이펙트|레벨에 비례해 사이즈가 다름|
|애니메이션|Animation|도넛의 레벨업시 실행됨|총 10개|

2) 도넛 가이드

|속성|영문명칭|설명|비고|
|-------|-----|-----|----|
|도넛사이클|Dount_Cycle|도넛의 단계별 모양을 알려준다|플레이씬에만 존재|


3) 메뉴

|속성|영문명칭|설명|비고|
|-------|-----|-----|----|
|볼륨조절|Volume|게임의 소리 음량 조정|슬라이더로 조절|
|중단하기|Option_Stop|게임도중 게임을 포기하고 나감|플레이씬에만 존재|
|게임종료|Option_Quit|앱을 종료함||
|계속하기|Option_Continue|계속 게임을 이어나감||

4) 배경

|속성|영문명칭|설명|비고|
|-------|-----|-----|----|
|배경|Background|도넛실루엣으로 패턴을 줌|이미지 컬러 핑크|

## c.행동

1) 도넛

|행동|영문명칭|설명|
|-------|-----|-----|
|아래로 이동|Down|손을 화면에서 놓을시 아래로 이동|
|왼쪽으로 이동|Left|손으로 왼쪽으로 드래그시 왼쪽으로 이동|
|오른쪽으로 이동|Right|손으로 오른쪽으로 드래그시 오른쪽으로 이동|
|소멸|Clear|오브젝트가 조건을 만족할시 소멸함|
|재소환|Respawn|이전 도넛이 아래로 이동하고 0.2초 대기 후 소환|
|접촉|Contact|다른 오브젝트에 접촉 collision, trigger에 따라 행동|

## d. 상태

1) 도넛

|현상태|전이상태|전이조건|
|-------|-----|-----|
|활성|비활성|같은 도넛을 접촉|
|활성|스프라이트 변경|단계가 올라감|
|활성|비활성|게임오버|

2) 스폰되는 도넛

|현상태|전이상태|전이조건|
|-------|-----|-----|
|활성|왼쪽으로 이동|손으로 왼쪽으로 드래그|
|활성|오른쪽으로 이동|손으로 오른쪽으로 드래그|
|활성|아래로 이동|손을 화면에서 땜|
|비활성|활성|이전 도넛이 낙하 후 0.2초 후|


## e. 게임의 규칙

### 1) 핵심 규칙

같은 모양의 도넛이 접촉시 합쳐지면서 다음 도넛으로 변한다.

도넛의 단계마다 흭득하는 점수가 다르다.

흰색 점선(DeadLine)에 도넛이 5초이상 머무를 시 게임오버된다.

마지막 단계 도넛이 만날 경우 소멸한다.


### 2) 보조 규칙

스폰되는 도넛은 최대 5단계이다.

초창기에는 1단계만 스폰되며 플레이어가 완성한

도넛의 단계에 비례하여 스폰되는 단계의 범위가 늘어난다.

## f. 게임에서 사용될 공식

도넛 스폰 공식

소환레벨 = (1~플레이어 달성 도넛 단계) 중 랜덤소환 

1<= 플레이어 달성 도넛 단계 <=5 가 조건이다.

*플레이어 달성 도넛 단계가 6이 되어도 5단계까지만 스폰된다.

## 개발 요구사항 & 흐름도

### a. 요구사항
1. 어느 기종에서든 20.5:9 의 해상도로 실행될것
2. 게임오버 될 시 점수를 기록할 것
3. 게임오버 될 시 쌓여있던 도넛들이 터지는 효과 넣을 것
4. 점수는 높은순으로 3등까지 기록할것
5. 타이틀에서 기록을 확인할 수 있도록 할 것
6. 옵션버튼은 모든 씬에서 위치가 고정일것
7. 플레이씬에서 도넛의 단계를 알 수 있도록 이미지를 추가할 것
8. 게임오버가 되어 결과창으로 가면 현재 점수가 나올 것
9. 타이틀에서 기록확인으로 가면 현재점수가 (----) 미표시로 나올 것
10. 게임오버 될 시 bgm이 일시적으로 멈출 것
11. 게임 도중에 옵션 버튼을 통해 중단이 가능할 것
12. 어느 씬이든 볼륨조절이 가능할 것
13. 플레이씬에서 현재점수는 중앙 상단에 나올 것
14. 드래그인식 범위는 화면 전체일 것
15. 씬전환중에 bgm이 끊기지 않을 것


### b. 이벤트 흐름도
![image](https://github.com/j0462/Growdonut/assets/70842040/8f3f7d72-94bd-46f9-81d4-60024bfed726)




# 개발작업 일정


## 1주차

카메라 수치 및 캔버스 사이즈 조절

해상도 조절을 위한 스크립트 작성

해상도는(1080*2460) 20.5:9 비율  *아이폰(20:9), 갤럭시플립z(21:9)

## 2주차

임시 도넛 스프라이트 11개 제작

도넛의 생성, 드래그, 드롭, 드롭후 재생성 스크립트 작성

## 3주차

프레임 고정화(60fps)

도넛의 생성 다양화(1~5단계)

도넛의 합성 스크립트 작성

## 4주차

대학 교수님에게 자문(애니메이션을 추가하는 것을 권함)

도넛 생성 애니메이션 10개 생성

합성시 효과 이펙트를 파티클을 이용하여 추가

## 5주차

외부에 맡긴 11개의 도넛 그래픽, 배경화면을 게임에 적용

게임오버+데드라인 스크립트 작성

Score 요소를 스크립트에 추가(UI 미제작)

## 6주차

StartScene, ResultScene 제작

기록갱식을 위한 스크립트 작성

Text폰트 선정

GameScene에 도넛 사이클 이미지 추가

## 7주차

UI에 옵션, 볼륨조절 기능, 점수 UI 추가

bgm, sfx 선별

## 8주차

사운드를 통괄하는 Soundmanager 제작

Soundmanager 스크립트 제작

bgm, sfx 추가

## 9주차

안드로이드 빌드 설정 및 빌드

테스트



## 10주차~

플레이스토어 출시를 위한 준비

비공개 테스트 진행중~~~



# 스크립트 코드

https://github.com/j0462/Growdonut/blob/main/Scripts/CameraFixed.cs - 해상도조절

https://github.com/j0462/Growdonut/blob/main/Scripts/Token.cs - 도넛(플레이씬)

https://github.com/j0462/Growdonut/blob/main/Scripts/StartToken.cs - 도넛(타이틀씬-배경용)

https://github.com/j0462/Growdonut/blob/main/Scripts/Startmanager.cs - 타이틀씬 메니저

https://github.com/j0462/Growdonut/blob/main/Scripts/Gamemanager.cs - 플레이씬 메니저

https://github.com/j0462/Growdonut/blob/main/Scripts/Resultmanager.cs - 결과(기록)씬 메니저

https://github.com/j0462/Growdonut/blob/main/Scripts/Soundmanager.cs - 사운드 메니저
