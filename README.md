# ELICXIRs_BaseFramework
An improved version of ELICXIRs_BaseFramework_OneScene to handle multiple scenes.

Copyright (c) 2022 ELICXIR

Released under the MIT license

https://opensource.org/licenses/mit-license.php

## �������@�ɂ���
ELICXIRs_BaseFramework(�ȉ��u���@�\�v)�𓱓�������@�͈ȉ��̒ʂ�ł��B

### 1.����������UnityProject��github�ŊǗ�����
github�ł��ꂩ��쐬����unity��project���Ǘ��ł���悤�ɂ��܂��傤�B

- UnityHub��NewProject�ŐV�����v���W�F�N�g�̃t�H���_���쐬����
- �쐬�����t�H���_�S�̂��Ǘ�����github�̃��|�W�g�����쐬����

### 2.���@�\�̓���
���@�\��submodule�Ƃ��ē������܂��B

https://github.com/elicxir/batchfiles
�ɏ]���ē������Ă��������B

Asset�z����BaseSystem�Ƃ����t�H���_���쐬����邽�ߋ������Ȃ��悤�ɂ��Ă��������B

Assets/BaseSystem�z���̃t�@�C����ύX�����update�����s���邱�Ƃ�����܂��B���̎���Assets/BaseSystem��Assets/BaseSystem_Customize���폜���Agitmodule���炱�̃v���W�F�N�g�̏����������㏉�߂����蒼���Ă��������B

Assets/BaseSystem_Customize�z���ɂ�GameManager.cs��GameEnums.cs�̃t�@�C�����ǉ�����܂��B���̓�̃t�@�C���͎����̍��Q�[���ɍ��킹�ď��������Ă��������B_


## ���p���@�ɂ���

### 1.GameManager�̍쐬
Assets/BaseSystem_Customize�z����GameManager.cs�����邽�߂�����g���Ă��������B

### 





### ����state�ɂ���

�ȉ���gamestate�͎��O�ɗp�r�����蓖�Ă��Ă���A���[�U�[������ύX���邱�Ƃ͂ł��܂���B

- Undefined
- Scene
- Loading

#### Undefined
�����������ȂǂɎg����u����`�v�̏�Ԃł��B�Q�[���J�n��͊�{�I�ɂ��̏�ԂɂȂ邱�Ƃ͂���܂���B

#### Scene
�ǂݍ��񂾃V�[���ɂ����Ă���"Scene_Executer"���p�������X�N���v�g���������Ƃ��ł��܂��B

����𗘗p���邱�ƂŃV�[�����ƂɈقȂ鏈�����s�����Ƃ��ł��܂��B�Ⴆ�΃A�N�V�����Q�[���ŃX�e�[�W���ƂɃV�[���𕪂���Scene�ň������Ƃɂ��X�e�[�W�ŗL�̏����Ȃǂ��܂߂ē���I�Ɉ������Ƃ��ł���悤�ɂȂ�ł��傤�B(���̂����킩��₷���f�������܂��B)

#### Loading
�V�[���̃��[�f�B���O���������Ă��Ȃ��Ƃ���Scene��ԂɈڍs���悤�Ƃ����Loading���Ă΂�܂��B�V�[���̃��[�h����������Ǝ����ł��̃V�[���Ɉڍs���܂��B

### Scene�̎w��ɂ���
�񋓌^��gamescene��p���ăQ�[�����Ɏg�p����V�[����1:1�Ή������Ă��܂��B�X�N���v�g��ł�gamescene��p���ăV�[���̈ڍs�������ł��܂��B

Build Settings �� Scenes In Builds �Ɋegamescene�ɑΉ�����V�[�������Ԓʂ�ɓo�^���Ă��������B

GameManagerScene�͕ύX���Ȃ����Ƃ������߂��܂��B

### ������Ԃɂ���




---
## ���̑����ɗ��@�\�̏Љ�

### �o�b�`�t�@�C��
#### add_basesystem.bat
 
���̃t���[�����[�N��submodule�Ƃ��ē����ł��܂��B(Asset�z����BaseSystem�t�H���_�ɂ��̃��|�W�g����Asset�z������������܂��B)

#### update.bat

submodule�̍X�V


### Test�N���X(Test.cs)
�f�o�b�O�p�̐ݒ肪�ł��܂��B

#### ShowLog
�ȉ���Log��\�����邩�̃t���O


#### Log
Unity��Debug.Log()�ɕ\���̃I���I�t�؂�ւ������܂���

#### 

### Miscs
���ɗ��Ǝv����ȉ��̋@�\�𓱓����Ă���܂��B
- EnumIndex:�z���Enum�̖��O��t���Ă킩��₷������B
    https://goropocha.hatenablog.com/entry/2021/02/11/232617
