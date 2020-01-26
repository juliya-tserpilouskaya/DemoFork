import { MAnswerVariant_ChoosingAnswerFromList } from '../AnswerVariants/MAnswerVariant_ChoosingAnswerFromList';

export interface MQuestion_ChoosingAnswerFromList {
  Id:             number;
  QuestionText:   string;
  SortKey:        number;
  AnswerVariants: MAnswerVariant_ChoosingAnswerFromList[];
}
