using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class KartAgent : Agent
{
   public CheckpointManager _checkpointManager;
   private KartController _kartController;
   
   public override void Initialize()
   {
      _kartController = GetComponent<KartController>();
   }
   
   public override void OnEpisodeBegin()
   {
      _checkpointManager.ResetCheckpoints();
      _kartController.Respawn();
   }

   public override void CollectObservations(VectorSensor sensor)
   {
      Vector3 diff = _checkpointManager.nextCheckPointToReach.transform.position - transform.position;
      sensor.AddObservation(diff / 20f);
      AddReward(-0.001f);
   }

   public override void OnActionReceived(ActionBuffers actions)
   {
      // Add rewards if the agent is heading in the right direction
      var direction = (_checkpointManager.transform.position - transform.position).normalized;
      var reward = Vector3.Dot(_kartController.sphereRB.velocity.normalized, direction);
        
      AddReward(reward * 0.00025f);
        

      var Actions = actions.ContinuousActions;
        _kartController.ApplyAcceleration(Actions[1]);
      _kartController.Steer(Actions[0]);
      _kartController.AnimateKart(Actions[0]);

        AddReward(Actions[1] * 0.00025f);

        if (Physics.Raycast(_kartController.transform.position, Vector3.down, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Goal")) AddReward(0.00025f);
        }

    }
   
   public override void Heuristic(in ActionBuffers actionsOut)
   {
      var continousActions = actionsOut.ContinuousActions;
      continousActions.Clear();
      
      continousActions[0] = Input.GetAxis("Horizontal");
      continousActions[1] = Input.GetAxis("Vertical");//Input.GetKey(KeyCode.W) ? 1f : 0f;
   }
}
