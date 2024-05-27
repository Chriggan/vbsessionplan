export type Drill = {
  id: string;
  name: string;
  description: string;
  atleastMinutes: number;
  recommendedMinutes: number;
  skills: Array<string>;
};
