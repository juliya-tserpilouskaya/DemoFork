import { MAnswerVariant_SetOrder } from '../AnswerVariants/MAnswerVariant_SetOrder';

export interface MQuestion_SetOrder {
  Id:             number;
  QuestionText:   string;
  SortKey:        number;
  AnswerVariants: MAnswerVariant_SetOrder[];
}
