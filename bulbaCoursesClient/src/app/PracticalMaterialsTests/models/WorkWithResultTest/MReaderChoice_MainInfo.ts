import { MReaderChoice_ChoosingAnswerFromList } from './MReaderChoice_ChoosingAnswerFromList';
import { MReaderChoice_SetOrder } from './MReaderChoice_SetOrder';

export interface MReaderChoice_MainInfo {
  Id:                                   number;
  ReaderChoices_ChoosingAnswerFromList: MReaderChoice_ChoosingAnswerFromList[];
  ReaderChoices_SetOrder:               MReaderChoice_SetOrder[];
}
