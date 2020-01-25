import { MAnswerVariant_SetOrder } from '../AnswerVariants/MAnswerVariant_SetOrder';

export interface MQuestion_SetOrder {
  QuestionText:   string;
  SortKey:        number;
  AnswerVariants: MAnswerVariant_SetOrder[];
}
