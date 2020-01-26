import { MQuestion_ChoosingAnswerFromList } from '../Questions/MQuestion_ChoosingAnswerFromList';
import { MQuestion_SetOrder } from '../Questions/MQuestion_SetOrder';

export interface MTest_MainInfo {
  Id:                               number;
  Name:                             string;
  Questions_ChoosingAnswerFromList: MQuestion_ChoosingAnswerFromList[];
  Questions_SetOrder:               MQuestion_SetOrder[];
}
