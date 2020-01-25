import { MAnswerVariant_ChoosingAnswerFromList } from '../AnswerVariants/MAnswerVariant_ChoosingAnswerFromList';

export interface MQuestion_ChoosingAnswerFromList {
  QuestionText:   string;
  SortKey:        number;
  AnswerVariants: MAnswerVariant_ChoosingAnswerFromList[];
}
